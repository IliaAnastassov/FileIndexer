﻿namespace FileIndexerApplication
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Models;

    // TODO: Application architecture - create two separate modes: live mode and loaded mode
    // TODO: Add search functionality in the indexed folder
    // TODO: Add command line arguments
    // TODO: Add copy/paste keyboard shortcuts to path text box
    public partial class FileIndexerMainForm : Form
    {
        private string currentPath;
        private List<string> subsequentPaths = new List<string>(8);

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
            PopulateListView(currentPath);
        }

        private void GoToButton_Click(object sender, EventArgs e)
        {
            currentPath = PathTextBox.Text;

            if (currentPath.Replace(" ", string.Empty) != string.Empty)
            {
                subsequentPaths.Add(currentPath);
                PopulateTreeView(currentPath);
                PopulateListView(currentPath);
                UpdatePathTextBox();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (subsequentPaths.Count > 1)
            {
                subsequentPaths.RemoveAt(subsequentPaths.Count - 1);
                currentPath = subsequentPaths[subsequentPaths.Count - 1];
                PopulateListView(currentPath);

                if (DirectoryChanged())
                {
                    PopulateTreeView(currentPath);
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
                    var loadedTree = FileIndexer.LoadTree(dialog.FileName);

                    currentPath = loadedTree.Path;
                    subsequentPaths.Add(currentPath);
                    UpdatePathTextBox();

                    PopulateTreeView(loadedTree);
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

        private void PopulateTreeView(string path)
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

        private void PopulateTreeView(FIDirectory tree)
        {
            TreeNode root = new TreeNode(tree.Name);

            MainFormTreeView.Nodes.Clear();

            root.ImageIndex = tree.ImageIndex;
            GetTreeViewFolders(root, tree);

            MainFormTreeView.Nodes.Add(root);
            root.Expand();
        }



        private void PopulateListView(string path)
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

        private void GetTreeViewFolders(TreeNode node, FIDirectory tree)
        {
            try
            {
                foreach (var subdir in tree.Subdirs)
                {
                    var childNode = new TreeNode(subdir.Name);
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