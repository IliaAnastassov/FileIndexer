namespace FileIndexerApplication
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Models;

    // TODO: Fix FileIndexerTreeView_AfterSelect method
    // TODO: Add search functionality in the indexed folder
    // TODO: Add command line arguments
    // TODO: Add copy/paste keyboard shortcuts to path text box
    public partial class FileIndexerMainForm : Form
    {
        private string currentPath;
        private List<string> subsequentPaths = new List<string>(8);
        private FIDirectory loadedDirectory;
        private bool isLive = true; // Application state is set to LIVE by default

        public FileIndexerMainForm()
        {
            InitializeComponent();
        }

        private void FileIndexerMainForm_Load(object sender, EventArgs e)
        {
            // When loaded with no path as argument, MyDocuments folder is the default root folder
            var root = new TreeNode("My Documents");
            root.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            currentPath = root.Tag.ToString();
            subsequentPaths.Add(currentPath);
            UpdatePathTextBox();

            // Populate the tree view with the default root folder
            MainFormTreeView.Nodes.Add(root);

            GetTreeViewFolders(root);
            root.Expand();
        }

        private void FileIndexerTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            currentPath = e.Node.Tag.ToString();

            subsequentPaths.Add(currentPath);
            UpdatePathTextBox();
            PopulateListViewStrategy(currentPath, isLive);
        }

        private void GoToButton_Click(object sender, EventArgs e)
        {
            // Reset application state to LIVE
            isLive = true;
            currentPath = PathTextBox.Text;

            if (currentPath.Replace(" ", string.Empty) != string.Empty)
            {
                subsequentPaths.Add(currentPath);
                PopulateTreeViewStrategy(currentPath, isLive);
                PopulateLiveListView(currentPath);
                UpdatePathTextBox();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (subsequentPaths.Count > 1)
            {
                subsequentPaths.RemoveAt(subsequentPaths.Count - 1);
                currentPath = subsequentPaths[subsequentPaths.Count - 1];
                PopulateLiveListView(currentPath);

                if (DirectoryChanged())
                {
                    PopulateTreeViewStrategy(currentPath, isLive);
                }

                UpdatePathTextBox();
            }
        }

        private void ViewToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ViewToolStripComboBox.Text)
            {
                case "Large Icons":
                    MainFormListView.View = View.LargeIcon;
                    break;
                case "Small Icons":
                    MainFormListView.View = View.SmallIcon;
                    break;
                case "Details":
                    MainFormListView.View = View.Details;
                    break;
                case "List":
                    MainFormListView.View = View.List;
                    break;
                case "Tiles":
                    MainFormListView.View = View.Tile;
                    break;
                default:
                    break;
            }
        }

        private void SaveIndexedDirButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Indexed Directory File|*.idf";
            dialog.AddExtension = true;
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var dirToIndex = new DirectoryInfo(currentPath);
                var indexedDir = new FIDirectory(dirToIndex.FullName, dirToIndex.Name, dirToIndex.LastWriteTime);

                FileIndexer.ExtractItems(dirToIndex, indexedDir);
                FileIndexer.SaveTree(indexedDir, dialog.FileName);
            }
        }

        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Indexed Directory File|*.idf";
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    loadedDirectory = FileIndexer.LoadTree(dialog.FileName);

                    currentPath = loadedDirectory.Path;
                    subsequentPaths.Add(currentPath);
                    UpdatePathTextBox();
                    isLive = false; // Set application state to LOAD

                    PopulateTreeViewStrategy(currentPath, isLive);
                    PopulateListViewStrategy(currentPath, isLive);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PathTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    GoToButton.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void UpdatePathTextBox()
        {
            PathTextBox.Text = currentPath;
        }

        private void PopulateTreeViewStrategy(string path, bool stateLive)
        {
            if (stateLive)
            {
                PopulateLiveTreeView(path);
            }
            else
            {
                PopulateLoadedTreeView(path);
            }
        }

        private void PopulateLoadedTreeView(string path)
        {
            var dir = FileIndexer.GetFIDirectory(path, loadedDirectory);

            if (dir != null)
            {
                TreeNode root = new TreeNode(dir.Name);

                MainFormTreeView.Nodes.Clear();

                root.Tag = dir.Path;
                root.ImageIndex = dir.ImageIndex;
                GetTreeViewFolders(root, dir);

                MainFormTreeView.Nodes.Add(root);
                root.Expand();
            }
        }

        private void PopulateLiveTreeView(string path)
        {
            TreeNode root;
            var dir = new DirectoryInfo(path);

            if (dir.Exists)
            {
                // Clear the existing nodes only in case of a valid path
                MainFormTreeView.Nodes.Clear();

                root = new TreeNode(dir.Name);
                root.Tag = dir;
                GetTreeViewFolders(root);

                MainFormTreeView.Nodes.Add(root);
                root.Expand();
            }
        }

        private void PopulateListViewStrategy(string path, bool stateLive)
        {
            if (stateLive)
            {
                PopulateLiveListView(path);
            }
            else
            {
                PopulateLoadedListView(path);
            }
        }

        private void PopulateLiveListView(string path)
        {
            var dir = new DirectoryInfo(path);

            MainFormListView.Items.Clear();
            LargeImageList.Images.RemoveByKey(".exe");
            SmallIimageList.Images.RemoveByKey(".exe");

            // Get the files in the selected directory and display them in the list view
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
                if (!LargeImageList.Images.ContainsKey(file.Extension))
                {
                    var icon = Icon.ExtractAssociatedIcon(file.FullName);
                    LargeImageList.Images.Add(file.Extension, icon);
                    SmallIimageList.Images.Add(file.Extension, icon);
                }

                item.ImageKey = file.Extension;
                MainFormListView.Items.Add(item);
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

                MainFormListView.Items.Add(item);
            }
        }

        private void PopulateLoadedListView(string path)
        {
            MainFormListView.Items.Clear();

            var dir = FileIndexer.GetFIDirectory(path, loadedDirectory);

            // Extract files
            foreach (var file in dir.Files)
            {
                var item = new ListViewItem(file.Name);
                item.ImageKey = file.Extension;
                item.SubItems.Add(file.LastModified.ToShortDateString() + " " + file.LastModified.ToShortTimeString());
                item.SubItems.Add(file.Extension);
                item.SubItems.Add(Math.Ceiling(file.Size / 1024d) + " KB");

                MainFormListView.Items.Add(item);
            }

            // Extract directories
            foreach (var subdir in dir.Subdirs)
            {
                var item = new ListViewItem(subdir.Name, subdir.ImageIndex);

                MainFormListView.Items.Add(item);
            }
        }

        private void GetTreeViewFolders(TreeNode node)
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

                    GetTreeViewFolders(childNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetTreeViewFolders(TreeNode node, FIDirectory dir)
        {
            try
            {
                foreach (var subdir in dir.Subdirs)
                {
                    var childNode = new TreeNode(subdir.Name);
                    childNode.Tag = subdir.Path;
                    childNode.ImageIndex = subdir.ImageIndex;

                    node.Nodes.Add(childNode);

                    GetTreeViewFolders(childNode, subdir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool DirectoryChanged()
        {
            if (currentPath[0] != PathTextBox.Text[0])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}