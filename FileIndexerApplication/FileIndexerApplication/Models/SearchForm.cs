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
            try
            {
                if (FileNameTextBox.Text != string.Empty)
                {
                    var fileName = FileNameTextBox.Text.ToLower();

                    FileSearcher.SearchByName(FileIndexerMainForm.LoadedDirectory, fileName, foundFiles);
                }
                if (MaxSizeTextBox.Text != string.Empty)
                {
                    var maxSize = int.Parse(MaxSizeTextBox.Text);

                    FileSearcher.SearchByMaxSize(FileIndexerMainForm.LoadedDirectory, maxSize, foundFiles);
                }
                if (MinSizeTextBox.Text != string.Empty)
                {
                    var minSize = int.Parse(MaxSizeTextBox.Text);

                    FileSearcher.SearchByMinSize(FileIndexerMainForm.LoadedDirectory, minSize, foundFiles);
                }
                if (DateModifiedTextBox.Text != string.Empty)
                {
                    var date = DateTime.Parse(DateModifiedTextBox.Text);

                    FileSearcher.SearchByDateModified(FileIndexerMainForm.LoadedDirectory, date, foundFiles);

                }
                if (FileExtensionTextBox.Text != string.Empty)
                {
                    var extension = FileExtensionTextBox.Text;

                    FileSearcher.SearchByFileExtension(FileIndexerMainForm.LoadedDirectory, extension, foundFiles);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Load the found files in the current instance of the FileIndexerMainForm class
            var mainForm = Application.OpenForms[0] as FileIndexerMainForm;
            mainForm.LoadFoundFiles(foundFiles);

            // Close the form after the search is done and clear the foundFiles list
            this.Close();
            foundFiles.Clear();
        }
    }
}
