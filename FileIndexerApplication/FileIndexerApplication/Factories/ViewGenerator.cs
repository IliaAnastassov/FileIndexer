namespace FileIndexerApplication.Factories
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Core;

    public class ViewGenerator
    {
        public static TreeView GenerateTreeView(string path, TreeView tree, bool liveState)
        {
            if (liveState)
            {
                return GenerateLiveTreeView(path, tree);
            }
            else
            {
                return GenerateLoadedTreeView(path, tree);
            }
        }

        public static ListView GenerateListView(string path, ListView listView, bool liveState)
        {
            if (liveState)
            {
                return GenerateLiveListView(path, listView);
            }
            else
            {
                return GenerateLoadedListView(path, listView);
            }
        }

        private static TreeView GenerateLiveTreeView(string path, TreeView tree)
        {
            TreeNode root;
            var dir = new DirectoryInfo(path);

            if (dir.Exists && !dir.Attributes.HasFlag(FileAttributes.ReadOnly))
            {
                // Clear the existing nodes only in case of a valid path
                tree.Nodes.Clear();

                root = new TreeNode(dir.Name);
                root.Tag = dir;
                FolderGenerator.GetFolders(root);

                tree.Nodes.Add(root);
                root.Expand();
            }

            return tree;
        }

        private static TreeView GenerateLoadedTreeView(string path, TreeView tree)
        {
            var dir = FileIndexer.FindFIDirectory(path, FileIndexerMainForm.LoadedDirectory);

            if (dir != null)
            {
                TreeNode root = new TreeNode(dir.Name);

                tree.Nodes.Clear();

                root.Tag = dir.Path;
                root.ImageIndex = dir.ImageIndex;
                FolderGenerator.GetFolders(root, dir);

                tree.Nodes.Add(root);
                root.Expand();
            }

            return tree;
        }

        private static ListView GenerateLiveListView(string path, ListView listView)
        {
            var dir = new DirectoryInfo(path);

            listView.Items.Clear();
            listView.LargeImageList.Images.RemoveByKey(".exe");
            listView.SmallImageList.Images.RemoveByKey(".exe");

            try
            {
                // Get the files in the selected directory and display them in the list view
                if (!dir.Attributes.HasFlag(FileAttributes.ReadOnly))
                {
                    foreach (var file in dir.GetFiles())
                    {
                        // Don't add hidden files
                        if (file.Attributes.HasFlag(FileAttributes.Hidden))
                        {
                            continue;
                        }

                        var item = new ListViewItem(file.Name);

                        // Populate the sub-items of the item
                        var lastModified = file.LastWriteTime;
                        item.SubItems.Add(lastModified.ToShortDateString() + " " + lastModified.ToShortTimeString());
                        item.SubItems.Add(file.Extension);
                        item.SubItems.Add(Math.Ceiling(file.Length / 1024d) + " KB");

                        // Add an icon only once
                        if (!listView.LargeImageList.Images.ContainsKey(file.Extension))
                        {
                            var icon = Icon.ExtractAssociatedIcon(file.FullName);
                            listView.LargeImageList.Images.Add(file.Extension, icon);
                            listView.SmallImageList.Images.Add(file.Extension, icon);
                        }

                        item.ImageKey = file.Extension;
                        listView.Items.Add(item);
                    }

                    // Get the folders in the selected directory and display them in the list view
                    foreach (var childDir in dir.GetDirectories())
                    {
                        // Don't add hidden directories
                        if (childDir.Attributes.HasFlag(FileAttributes.Hidden))
                        {
                            continue;
                        }

                        // Create a list view item with the folder image index (0)
                        var item = new ListViewItem(childDir.Name, 0);

                        listView.Items.Add(item);
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (UnauthorizedAccessException accessEx)
            {
                MessageBox.Show(accessEx.Message);
            }

            return listView;
        }

        private static ListView GenerateLoadedListView(string path, ListView listView)
        {
            listView.Items.Clear();

            var dir = FileIndexer.FindFIDirectory(path, FileIndexerMainForm.LoadedDirectory);

            // Extract files
            foreach (var file in dir.Files)
            {
                var item = new ListViewItem(file.Name, file.ImageIndex);
                item.SubItems.Add(file.LastModified.ToShortDateString() + " " + file.LastModified.ToShortTimeString());
                item.SubItems.Add(file.Extension);
                item.SubItems.Add(Math.Ceiling(file.Size / 1024d) + " KB");

                listView.Items.Add(item);
            }

            // Extract directories
            foreach (var subdir in dir.Subdirs)
            {
                var item = new ListViewItem(subdir.Name, subdir.ImageIndex);

                listView.Items.Add(item);
            }

            return listView;
        }
    }
}