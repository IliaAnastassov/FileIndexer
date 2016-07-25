using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileIndexerApplication
{
    public partial class FileIndexerMainForm : Form
    {
        private string inputPath = string.Empty;
        private List<string> subsequentPaths = new List<string>(8); // Estimation

        public FileIndexerMainForm()
        {
            InitializeComponent();
        }

        private void FileIndexerMainForm_Load(object sender, EventArgs e)
        {
            // When loaded with no path as argument, MyDocuments folder is the default root folder
            var root = new TreeNode("My Documents");
            root.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Populate the tree view with the default root folder
            MainFormTreeView.Nodes.Add(root);

            GetFolders(root);
            root.Expand();
        }

        /// <summary>
        /// Event handler of the Tree View select node event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileIndexerTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var dir = new DirectoryInfo(e.Node.Tag.ToString());
            MainFormListView.Items.Clear();
            LargeImageList.Images.RemoveByKey(".exe");
            SmallIimageList.Images.RemoveByKey(".exe");

            // Get the files in the selected directory and display them in the list view
            foreach (var file in dir.GetFiles())
            {
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
                // If access to a folder is restricted don't display  it
                if (childDir.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    continue;
                }

                // Create a list view item with the folder image index (0)
                var item = new ListViewItem(childDir.Name, 0);

                MainFormListView.Items.Add(item);
            }
        }

        /// <summary>
        /// Event handler of the View Tool Strip Combo Box change view event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void GoToButton_Click(object sender, EventArgs e)
        {
            // TODO:
            inputPath = PathTextBox.Text;

            if (inputPath.Replace(" ", string.Empty) != string.Empty)
            {
                subsequentPaths.Add(inputPath);
                LoadDirectory(inputPath);
            }
        }

        /// <summary>
        /// Index a folder and all of its contents recursively
        /// </summary>
        /// <param name="node"></param>
        private void GetFolders(TreeNode node)
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadDirectory(string path)
        {
            TreeNode root;
            var dir = new DirectoryInfo(path);

            if (dir.Exists)
            {
                // Clear the existing nodes
                MainFormTreeView.Nodes.Clear();

                root = new TreeNode(dir.Name);
                root.Tag = dir;
                GetFolders(root);

                MainFormTreeView.Nodes.Add(root);
            }
        }
    }
}
