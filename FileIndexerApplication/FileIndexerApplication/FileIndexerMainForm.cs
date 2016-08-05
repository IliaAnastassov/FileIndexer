//-----------------------------------------------------------------------
// <copyright file="FileIndexerMainForm.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace FileIndexerApplication
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using Core;
    using Models;
    using Factories;
    using System.Linq;

    // TODO: Extract FormLoader class
    // TODO: Add search functionality in the indexed folder - modular tree view / list view display results
    // TODO: Add return type to strategy ERROR!!!
    // TODO: Add copy/paste keyboard shortcuts to path text box
    public partial class FileIndexerMainForm : Form
    {
        private string currentPath;
        private List<string> subsequentPaths = new List<string>(8);
        private static FIDirectory loadedDirectory;
        private bool isLive = true; // Application state is set to LIVE by default]
        private bool invalidPath;

        public static FIDirectory LoadedDirectory
        {
            get { return loadedDirectory; }

            private set { loadedDirectory = value; }
        }

        public FileIndexerMainForm()
        {
            InitializeComponent();
        }

        public FileIndexerMainForm(string argument)
        {
            currentPath = argument;

            InitializeComponent();
        }

        private void FileIndexerMainForm_Load(object sender, EventArgs e)
        {
            if (currentPath == null)
            {
                // When loaded with no path as argument, MyDocuments folder is the default root folder
                var root = new TreeNode("My Documents");
                root.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                currentPath = root.Tag.ToString();
                subsequentPaths.Add(currentPath);
                UpdatePathTextBox();

                // Populate the tree view with the default root folder
                MainFormTreeView.Nodes.Add(root);

                try
                {
                    FolderGenerator.GetFolders(root);
                }
                catch (DirectoryNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                    invalidPath = true;
                }

                root.Expand();
            }
            else
            {
                // Extract the appropriate name for the root node from the path using linq
                var rootName = currentPath.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).ToArray().Last();
                var root = new TreeNode(rootName);
                root.Tag = currentPath;
                subsequentPaths.Add(currentPath);
                UpdatePathTextBox();

                // Populate the tree view with the default root folder
                MainFormTreeView.Nodes.Add(root);

                try
                {
                    FolderGenerator.GetFolders(root);
                }
                catch (DirectoryNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                    invalidPath = true;
                }

                root.Expand();
            }
        }

        private void FileIndexerTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (invalidPath)
            {
                ResetMainForm();
            }
            else
            {
                currentPath = e.Node.Tag.ToString();

                subsequentPaths.Add(currentPath);
                UpdatePathTextBox();

                ViewGenerator.GenerateListView(currentPath, MainFormListView, isLive);
            }
        }

        private void GoToButton_Click(object sender, EventArgs e)
        {
            // Reset application state to LIVE
            isLive = true;
            currentPath = PathTextBox.Text;

            if (currentPath.Replace(" ", string.Empty) != string.Empty)
            {
                subsequentPaths.Add(currentPath);

                ViewGenerator.GenerateTreeView(currentPath, MainFormTreeView, isLive);
                ViewGenerator.GenerateListView(currentPath, MainFormListView, isLive);

                UpdatePathTextBox();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (subsequentPaths.Count > 1)
            {
                subsequentPaths.RemoveAt(subsequentPaths.Count - 1);
                currentPath = subsequentPaths[subsequentPaths.Count - 1];
                ViewGenerator.GenerateListView(currentPath, MainFormListView, isLive);

                if (DirectoryChanged())
                {
                    ViewGenerator.GenerateTreeView(currentPath, MainFormTreeView, isLive);
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
                    LoadedDirectory = FileIndexer.LoadTree(dialog.FileName);

                    currentPath = LoadedDirectory.Path;
                    subsequentPaths.Clear();
                    subsequentPaths.Add(currentPath);
                    UpdatePathTextBox();
                    isLive = false; // Set application state to LOAD

                    ViewGenerator.GenerateTreeView(currentPath, MainFormTreeView, isLive);
                    ViewGenerator.GenerateListView(currentPath, MainFormListView, isLive);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void ResetMainForm()
        {
            currentPath = string.Empty;
            subsequentPaths.Clear();
            UpdatePathTextBox();
            MainFormListView.Items.Clear();
            MainFormTreeView.Nodes.Clear();
            loadedDirectory = null;
            invalidPath = false;
            isLive = true;
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

        public void UpdatePathTextBox()
        {
            PathTextBox.Text = currentPath;
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