namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Factories;

    public partial class SearchForm : Form
    {
        private IList<FIFile> extractedFiles = new List<FIFile>();

        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            extractedFiles = FileGenerator.GetFiles(FileIndexerMainForm.LoadedDirectory);
            var searcher = new FileSearcher();

            try
            {
                extractedFiles = searcher.SearchFiles(
                    extractedFiles,
                    FileNameTextBox.Text,
                    MaxSizeTextBox.Text,
                    MinSizeTextBox.Text,
                    DateModifiedTextBox.Text,
                    FileExtensionTextBox.Text);
            }
            catch (FormatException exF)
            {
                MessageBox.Show(exF.Message);
            }
            catch (ArgumentException exA)
            {
                MessageBox.Show(exA.Message);
            }

            // Close the form after the search is done
            this.Close();

            // Load the found files in the current instance of the FileIndexerMainForm class
            var mainForm = Application.OpenForms[0] as FileIndexerMainForm;
            mainForm.LoadFoundFiles(extractedFiles);

            // Clear the foundFiles list
            extractedFiles.Clear();
        }
    }
}
