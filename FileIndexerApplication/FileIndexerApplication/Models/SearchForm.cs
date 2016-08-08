namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class SearchForm : Form
    {
        private List<FIFile> foundFiles = new List<FIFile>();

        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (FileNameTextBox.Text != null)
            {
                var fileName = FileNameTextBox.Text.ToLower();
                try
                {
                    FileSearcher.SearchByname(FileIndexerMainForm.LoadedDirectory, fileName, foundFiles);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (MaxSizeTextBox.Text != null)
            {
                // TODO
            }
            if (MinSizeTextBox.Text != null)
            {
                // TODO
            }
            if (DateModifiedTextBox.Text != null)
            {
                // TODO
            }
            if (FileExtensionTextBox.Text != null)
            {
                // TODO
            }

            this.Close();
            var mainForm = Application.OpenForms[0] as FileIndexerMainForm;
            mainForm.LoadFoundFiles(foundFiles);
        }
    }
}
