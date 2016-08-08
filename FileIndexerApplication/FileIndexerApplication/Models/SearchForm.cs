namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
                    var size = EvaluateSize(MaxSizeTextBox.Text);

                    if (size < 0)
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        FileSearcher.SearchByMaxSize(FileIndexerMainForm.LoadedDirectory, size, foundFiles);
                    }
                }
                if (MinSizeTextBox.Text != string.Empty)
                {
                    var size = EvaluateSize(MinSizeTextBox.Text);

                    if (size < 0)
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        FileSearcher.SearchByMinSize(FileIndexerMainForm.LoadedDirectory, size, foundFiles);
                    }
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
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Close the form after the search is done
            this.Close();

            // Load the found files in the current instance of the FileIndexerMainForm class
            var mainForm = Application.OpenForms[0] as FileIndexerMainForm;
            mainForm.LoadFoundFiles(foundFiles);

            // Clear the foundFiles list
            foundFiles.Clear();
        }

        private long EvaluateSize(string inputStr)
        {
            var input = inputStr.Split().ToArray();
            var size = long.Parse(input[0]);

            if (input[1].ToUpper() == "KB")
            {
                size *= 1000;
            }
            else if (input[1].ToUpper() == "MB")
            {
                size *= 1000000;
            }
            else if (input[1].ToUpper() == "GB")
            {
                size *= 1000000000;
            }
            else
            {
                size = -1;
            }

            return size;
        }
    }
}
