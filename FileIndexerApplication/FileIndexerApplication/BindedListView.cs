namespace FileIndexerApplication
{
    using System;
    using System.Windows.Forms;

    public class BindedListView : ListView
    {
        private TreeView tree;
        private TreeNode treeNode;

        public TreeView Tree
        {
            get { return tree; }
            set
            {
                if (value != null)
                {
                    this.tree = value;
                    this.Populate();
                }
            }
        }

        private void Populate()
        {
            this.Items.Clear();
            this.Items.Add("...");
            this.treeNode = tree.Nodes[0];
            this.SmallImageList = tree.ImageList;
            this.LargeImageList = tree.ImageList;

            for (int i = 0; i < tree.Nodes.Count - 1; i++)
            {
                this.Items.Add(tree.Nodes[i].Text);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (SelectedIndices.Count == 1)
            {
                if (SelectedIndices[0] > 0)
                {
                    StepIn();
                }
                else
                {
                    StepOut();
                }
            }
        }

        private void StepIn()
        {
            try
            {
                var inner = this.SelectedIndices[0] - 1;

                if (treeNode.Nodes[inner].Nodes.Count == 0)
                {
                    return;
                }

                this.Items.Clear();
                this.Items.Add("...");

                for (int i = 0; i < treeNode.Nodes[inner].Nodes.Count - 1; i++)
                {
                    this.Items.Add(treeNode.Nodes[inner].Nodes[i].Text, treeNode.Nodes[inner].Nodes[i].ImageIndex);
                }

                treeNode = treeNode.Nodes[inner];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StepOut()
        {
            try
            {
                if (treeNode.Parent.Nodes.Count == 0)
                {
                    return;
                }

                this.Items.Clear();
                this.Items.Add("...");

                for (int i = 0; i < treeNode.Parent.Nodes.Count - 1; i++)
                {
                    this.Items.Add(treeNode.Parent.Nodes[i].Text, treeNode.Parent.Nodes[i].ImageIndex);
                }

                treeNode = treeNode.Parent;
                treeNode.Text = treeNode.FullPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
