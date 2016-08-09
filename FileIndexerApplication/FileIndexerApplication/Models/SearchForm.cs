namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Factories;

    public partial class SearchForm : Form
    {
        private IList<FIFile> extractedFiles = new List<FIFile>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchForm" /> class
        /// </summary>
        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var invalidInput = false;

            if (!EmptyInput())
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
                    invalidInput = true;
                }
                catch (ArgumentException exA)
                {
                    MessageBox.Show(exA.Message);
                    invalidInput = true;
                }

                if (!invalidInput)
                {
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

        private bool EmptyInput()
        {
            if (FileNameTextBox.Text == string.Empty
                && MaxSizeTextBox.Text == string.Empty
                && MinSizeTextBox.Text == string.Empty
                && DateModifiedTextBox.Text == string.Empty
                && FileExtensionTextBox.Text == string.Empty)
            {
                return true;
            }

            return false;
        }

        private void SearchForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    MessageBox.Show(e.KeyChar.ToString());
                    SearchButton.PerformClick();
                    break;
                case (char)Keys.Escape:
                    MessageBox.Show(e.KeyChar.ToString());
                    Close();
                    break;
                default:
                    break;
            }
        }
    }
}
