namespace FileIndexerApplication.Factories
{
    using System.IO;
    using System.Windows.Forms;
    using Models;

    public class FolderGenerator
    {
        public static void GetFolders(TreeNode node)
        {
            var dir = new DirectoryInfo(node.Tag.ToString());

            try
            {
                // Recursively add all child nodes to the application tree view
                foreach (var childDir in dir.GetDirectories())
                {
                    // If access to a folder is restricted don't display  it
                    if (childDir.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        continue;
                    }

                    var childNode = new TreeNode(childDir.Name);
                    childNode.Tag = childDir.FullName;
                    node.Nodes.Add(childNode);

                    GetFolders(childNode);
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }
        }

        public static void GetFolders(TreeNode node, FIDirectory dir)
        {
            try
            {
                foreach (var subdir in dir.Subdirs)
                {
                    var childNode = new TreeNode(subdir.Name);
                    childNode.Tag = subdir.Path;
                    childNode.ImageIndex = subdir.ImageIndex;

                    node.Nodes.Add(childNode);

                    GetFolders(childNode, subdir);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
