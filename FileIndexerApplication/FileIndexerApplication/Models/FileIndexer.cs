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
    }
}
