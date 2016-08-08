namespace FileIndexerApplication.Models
{
    partial class SearchForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.MinSizeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FileExtensionTextBox = new System.Windows.Forms.TextBox();
            this.FileExtensionLabel = new System.Windows.Forms.Label();
            this.DateModifiedTextBox = new System.Windows.Forms.TextBox();
            this.DateModifiedLabel = new System.Windows.Forms.Label();
            this.MaxSizeTextBox = new System.Windows.Forms.TextBox();
            this.MaxSizeLabel = new System.Windows.Forms.Label();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MinSizeTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.FileExtensionTextBox);
            this.panel1.Controls.Add(this.FileExtensionLabel);
            this.panel1.Controls.Add(this.DateModifiedTextBox);
            this.panel1.Controls.Add(this.DateModifiedLabel);
            this.panel1.Controls.Add(this.MaxSizeTextBox);
            this.panel1.Controls.Add(this.MaxSizeLabel);
            this.panel1.Controls.Add(this.FileNameTextBox);
            this.panel1.Controls.Add(this.FileNameLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 174);
            this.panel1.TabIndex = 0;
            // 
            // MinSizeTextBox
            // 
            this.MinSizeTextBox.Location = new System.Drawing.Point(101, 75);
            this.MinSizeTextBox.Name = "MinSizeTextBox";
            this.MinSizeTextBox.Size = new System.Drawing.Size(121, 20);
            this.MinSizeTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Min Size";
            // 
            // FileExtensionTextBox
            // 
            this.FileExtensionTextBox.Location = new System.Drawing.Point(101, 139);
            this.FileExtensionTextBox.Name = "FileExtensionTextBox";
            this.FileExtensionTextBox.Size = new System.Drawing.Size(121, 20);
            this.FileExtensionTextBox.TabIndex = 7;
            // 
            // FileExtensionLabel
            // 
            this.FileExtensionLabel.AutoSize = true;
            this.FileExtensionLabel.Location = new System.Drawing.Point(3, 142);
            this.FileExtensionLabel.Name = "FileExtensionLabel";
            this.FileExtensionLabel.Size = new System.Drawing.Size(72, 13);
            this.FileExtensionLabel.TabIndex = 6;
            this.FileExtensionLabel.Text = "File Extension";
            // 
            // DateModifiedTextBox
            // 
            this.DateModifiedTextBox.Location = new System.Drawing.Point(101, 107);
            this.DateModifiedTextBox.Name = "DateModifiedTextBox";
            this.DateModifiedTextBox.Size = new System.Drawing.Size(121, 20);
            this.DateModifiedTextBox.TabIndex = 5;
            // 
            // DateModifiedLabel
            // 
            this.DateModifiedLabel.AutoSize = true;
            this.DateModifiedLabel.Location = new System.Drawing.Point(3, 110);
            this.DateModifiedLabel.Name = "DateModifiedLabel";
            this.DateModifiedLabel.Size = new System.Drawing.Size(73, 13);
            this.DateModifiedLabel.TabIndex = 4;
            this.DateModifiedLabel.Text = "Date Modified";
            // 
            // MaxSizeTextBox
            // 
            this.MaxSizeTextBox.Location = new System.Drawing.Point(101, 43);
            this.MaxSizeTextBox.Name = "MaxSizeTextBox";
            this.MaxSizeTextBox.Size = new System.Drawing.Size(121, 20);
            this.MaxSizeTextBox.TabIndex = 3;
            // 
            // MaxSizeLabel
            // 
            this.MaxSizeLabel.AutoSize = true;
            this.MaxSizeLabel.Location = new System.Drawing.Point(3, 46);
            this.MaxSizeLabel.Name = "MaxSizeLabel";
            this.MaxSizeLabel.Size = new System.Drawing.Size(50, 13);
            this.MaxSizeLabel.TabIndex = 2;
            this.MaxSizeLabel.Text = "Max Size";
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(101, 11);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.FileNameTextBox.TabIndex = 1;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(3, 14);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(54, 13);
            this.FileNameLabel.TabIndex = 0;
            this.FileNameLabel.Text = "File Name";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(159, 192);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 226);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.panel1);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox DateModifiedTextBox;
        private System.Windows.Forms.Label DateModifiedLabel;
        private System.Windows.Forms.TextBox MaxSizeTextBox;
        private System.Windows.Forms.Label MaxSizeLabel;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.TextBox FileExtensionTextBox;
        private System.Windows.Forms.Label FileExtensionLabel;
        private System.Windows.Forms.TextBox MinSizeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SearchButton;
    }
}