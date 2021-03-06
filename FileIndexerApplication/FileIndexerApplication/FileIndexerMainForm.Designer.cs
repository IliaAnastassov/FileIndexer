﻿namespace FileIndexerApplication
{
    partial class FileIndexerMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileIndexerMainForm));
            this.FileIndexerMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileIndexerMainToolStrip = new System.Windows.Forms.ToolStrip();
            this.BackButton = new System.Windows.Forms.ToolStripButton();
            this.ForwardButton = new System.Windows.Forms.ToolStripButton();
            this.SaveIndexedDirButton = new System.Windows.Forms.ToolStripButton();
            this.PathTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.GoToButton = new System.Windows.Forms.ToolStripButton();
            this.SearchButton = new System.Windows.Forms.ToolStripButton();
            this.ViewToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MainFormTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.MainFormListView = new System.Windows.Forms.ListView();
            this.NameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SizeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LargeImageList = new System.Windows.Forms.ImageList(this.components);
            this.SmallIimageList = new System.Windows.Forms.ImageList(this.components);
            this.FileIndexerMainMenuStrip.SuspendLayout();
            this.FileIndexerMainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileIndexerMainMenuStrip
            // 
            this.FileIndexerMainMenuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.FileIndexerMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.FileIndexerMainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.FileIndexerMainMenuStrip.Name = "FileIndexerMainMenuStrip";
            this.FileIndexerMainMenuStrip.Size = new System.Drawing.Size(944, 24);
            this.FileIndexerMainMenuStrip.TabIndex = 0;
            this.FileIndexerMainMenuStrip.Text = "Main menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // ImportToolStripMenuItem
            // 
            this.ImportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ImportToolStripMenuItem.Image")));
            this.ImportToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem";
            this.ImportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.ImportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ImportToolStripMenuItem.Text = "&Import";
            this.ImportToolStripMenuItem.Click += new System.EventHandler(this.ImportToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Image = global::FileIndexerApplication.Properties.Resources.save;
            this.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SaveToolStripMenuItem.Text = "&Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveIndexedDirButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // FileIndexerMainToolStrip
            // 
            this.FileIndexerMainToolStrip.BackColor = System.Drawing.SystemColors.Window;
            this.FileIndexerMainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.FileIndexerMainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackButton,
            this.ForwardButton,
            this.SaveIndexedDirButton,
            this.PathTextBox,
            this.GoToButton,
            this.SearchButton,
            this.ViewToolStripComboBox});
            this.FileIndexerMainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.FileIndexerMainToolStrip.Name = "FileIndexerMainToolStrip";
            this.FileIndexerMainToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.FileIndexerMainToolStrip.Size = new System.Drawing.Size(944, 33);
            this.FileIndexerMainToolStrip.TabIndex = 1;
            this.FileIndexerMainToolStrip.Text = "Main tools";
            // 
            // BackButton
            // 
            this.BackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(23, 20);
            this.BackButton.Text = "Step back";
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ForwardButton
            // 
            this.ForwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ForwardButton.Image = ((System.Drawing.Image)(resources.GetObject("ForwardButton.Image")));
            this.ForwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(23, 20);
            this.ForwardButton.Text = "Step Forward";
            // 
            // SaveIndexedDirButton
            // 
            this.SaveIndexedDirButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveIndexedDirButton.Image = global::FileIndexerApplication.Properties.Resources.save;
            this.SaveIndexedDirButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveIndexedDirButton.Name = "SaveIndexedDirButton";
            this.SaveIndexedDirButton.Size = new System.Drawing.Size(23, 20);
            this.SaveIndexedDirButton.Text = "Save Indexed Directory";
            this.SaveIndexedDirButton.Click += new System.EventHandler(this.SaveIndexedDirButton_Click);
            // 
            // PathTextBox
            // 
            this.PathTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.PathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PathTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(600, 23);
            this.PathTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PathTextBox_KeyPress);
            // 
            // GoToButton
            // 
            this.GoToButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GoToButton.Image = ((System.Drawing.Image)(resources.GetObject("GoToButton.Image")));
            this.GoToButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GoToButton.Name = "GoToButton";
            this.GoToButton.Size = new System.Drawing.Size(23, 20);
            this.GoToButton.Text = "Go to address";
            this.GoToButton.Click += new System.EventHandler(this.GoToButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SearchButton.Image = global::FileIndexerApplication.Properties.Resources._1_search;
            this.SearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(23, 20);
            this.SearchButton.Text = "Search";
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ViewToolStripComboBox
            // 
            this.ViewToolStripComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewToolStripComboBox.Items.AddRange(new object[] {
            "Large Icons",
            "Small Icons",
            "Details",
            "List",
            "Tiles"});
            this.ViewToolStripComboBox.Name = "ViewToolStripComboBox";
            this.ViewToolStripComboBox.Size = new System.Drawing.Size(100, 23);
            this.ViewToolStripComboBox.Text = "View";
            this.ViewToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.ViewToolStripComboBox_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(944, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 57);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MainFormTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MainFormListView);
            this.splitContainer1.Size = new System.Drawing.Size(944, 482);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.TabIndex = 3;
            // 
            // MainFormTreeView
            // 
            this.MainFormTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormTreeView.ImageIndex = 0;
            this.MainFormTreeView.ImageList = this.TreeViewImageList;
            this.MainFormTreeView.Location = new System.Drawing.Point(0, 0);
            this.MainFormTreeView.Name = "MainFormTreeView";
            this.MainFormTreeView.SelectedImageIndex = 0;
            this.MainFormTreeView.Size = new System.Drawing.Size(198, 482);
            this.MainFormTreeView.TabIndex = 0;
            this.MainFormTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FileIndexerTreeView_AfterSelect);
            // 
            // TreeViewImageList
            // 
            this.TreeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeViewImageList.ImageStream")));
            this.TreeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeViewImageList.Images.SetKeyName(0, "FolderIcon.png");
            // 
            // MainFormListView
            // 
            this.MainFormListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.MainFormListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameCol,
            this.DateCol,
            this.TypeCol,
            this.SizeCol});
            this.MainFormListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormListView.LargeImageList = this.LargeImageList;
            this.MainFormListView.Location = new System.Drawing.Point(0, 0);
            this.MainFormListView.Name = "MainFormListView";
            this.MainFormListView.Size = new System.Drawing.Size(742, 482);
            this.MainFormListView.SmallImageList = this.SmallIimageList;
            this.MainFormListView.TabIndex = 0;
            this.MainFormListView.UseCompatibleStateImageBehavior = false;
            // 
            // NameCol
            // 
            this.NameCol.Text = "Name";
            this.NameCol.Width = 250;
            // 
            // DateCol
            // 
            this.DateCol.Text = "Date modified";
            this.DateCol.Width = 150;
            // 
            // TypeCol
            // 
            this.TypeCol.Text = "Type";
            this.TypeCol.Width = 150;
            // 
            // SizeCol
            // 
            this.SizeCol.Text = "Size";
            this.SizeCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SizeCol.Width = 75;
            // 
            // LargeImageList
            // 
            this.LargeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LargeImageList.ImageStream")));
            this.LargeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.LargeImageList.Images.SetKeyName(0, "folder.png");
            this.LargeImageList.Images.SetKeyName(1, "3_Document.png");
            // 
            // SmallIimageList
            // 
            this.SmallIimageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallIimageList.ImageStream")));
            this.SmallIimageList.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallIimageList.Images.SetKeyName(0, "folder.png");
            this.SmallIimageList.Images.SetKeyName(1, "3_Document.png");
            // 
            // FileIndexerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(944, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.FileIndexerMainToolStrip);
            this.Controls.Add(this.FileIndexerMainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.FileIndexerMainMenuStrip;
            this.Name = "FileIndexerMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileIndexer";
            this.Load += new System.EventHandler(this.FileIndexerMainForm_Load);
            this.FileIndexerMainMenuStrip.ResumeLayout(false);
            this.FileIndexerMainMenuStrip.PerformLayout();
            this.FileIndexerMainToolStrip.ResumeLayout(false);
            this.FileIndexerMainToolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip FileIndexerMainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip FileIndexerMainToolStrip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView MainFormTreeView;
        private System.Windows.Forms.ListView MainFormListView;
        private System.Windows.Forms.ToolStripTextBox PathTextBox;
        private System.Windows.Forms.ImageList LargeImageList;
        private System.Windows.Forms.ImageList SmallIimageList;
        private System.Windows.Forms.ToolStripComboBox ViewToolStripComboBox;
        private System.Windows.Forms.ColumnHeader NameCol;
        private System.Windows.Forms.ColumnHeader DateCol;
        private System.Windows.Forms.ColumnHeader TypeCol;
        private System.Windows.Forms.ColumnHeader SizeCol;
        private System.Windows.Forms.ImageList TreeViewImageList;
        private System.Windows.Forms.ToolStripButton BackButton;
        private System.Windows.Forms.ToolStripButton ForwardButton;
        private System.Windows.Forms.ToolStripButton SaveIndexedDirButton;
        private System.Windows.Forms.ToolStripButton GoToButton;
        private System.Windows.Forms.ToolStripMenuItem ImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton SearchButton;
    }
}

