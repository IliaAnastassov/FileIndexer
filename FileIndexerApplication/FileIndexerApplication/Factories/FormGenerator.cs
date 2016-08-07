namespace FileIndexerApplication.Factories
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    public class FormGenerator
    {
        public static TreeView LoadTree(TreeView tree, string path)
        {
            var root = new TreeNode();

            if (path == null)
            {
                // When loaded with no path as argument, MyDocuments folder is the default root folder
                root.Text = "My Documents";
                root.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path = root.Tag.ToString();

                // Populate the tree view with the default root folder
                tree.Nodes.Add(root);
            }
            else
            {
                // Extract the appropriate name for the root node from the path using linq
                var rootName = path.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).ToArray().Last();
                root.Text = rootName;
                root.Tag = path;

                // Populate the tree view with the command line argument path
                tree.Nodes.Add(root);
            }

            // Get all the containing subfolders of the root folder
            try
            {
                FolderGenerator.GetFolders(root);
            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }

            root.Expand();

            return tree;
        }
    }
}
