using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileIndexerApplication
{
    public partial class FileIndexerMainForm : Form
    {
        public FileIndexerMainForm()
        {
            InitializeComponent();
        }

        private void FileIndexerMainForm_Load(object sender, EventArgs e)
        {
            // When loaded with no path as argument, the MyDocuments folder shows in the tree view
            var root = new TreeNode("My Documents");
            root.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            FileIndexerTreeView.Nodes.Add(root);

            GetFolders(root);
            root.Expand();
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
    }
}
