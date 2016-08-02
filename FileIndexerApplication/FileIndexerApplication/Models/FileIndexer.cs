namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;
    using Contracts;

    public class FileIndexer
    {
        public static void SaveIndexTree(TreeView tree, string filename)
        {
            using (Stream file = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, tree.Nodes.Cast<TreeNode>().ToList());
            }
        }

        public static void LoadIndexTree(TreeView tree, string filename)
        {
            using (Stream file = File.Open(filename, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                var obj = bf.Deserialize(file);

                TreeNode[] nodes = (obj as IEnumerable<TreeNode>).ToArray();
                tree.Nodes.Clear();
                tree.Nodes.AddRange(nodes);
                tree.Nodes[0].Expand();
            }
        }

        public static void SaveTree(DirectoryInfo root, string filename)
        {
            // Create a new fiDirectory object and populate it with
            // info from the DirectoryInfo object
            var fiRoot = new FIDirectory(root.FullName, root.Name, root.LastWriteTime);


        }

        private void ExtractItems(DirectoryInfo dir, FIDirectory fiDir)
        {
            // Extract needed information about the containing files of the DirectoryInfo object
            // and store it in the FIDirectory object
            foreach (var file in dir.GetFiles())
            {
                if (file.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    continue;
                }
                fiDir.AddFile(new FIFile(file.Name, file.FullName, file.Extension, file.LastWriteTime, file.Length));
            }

            try
            {
                // Recursively extract needed information about all the subdirectories and their
                // subdirectories of the Directoryinfo object and save it to the FIDirectory object
                foreach (var subdir in dir.GetDirectories())
                {
                    if (subdir.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        continue;
                    }

                    var fiSubdir = new FIDirectory(subdir.FullName, subdir.Name, subdir.LastWriteTime);
                    fiDir.AddSubdirectory(fiSubdir);

                    ExtractItems(subdir, fiSubdir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
