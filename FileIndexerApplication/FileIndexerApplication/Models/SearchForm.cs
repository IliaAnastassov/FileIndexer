namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Factories;

    public partial class SearchForm : Form
    {
        private List<FIFile> extractedFiles = new List<FIFile>();

        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            extractedFiles = FileGenerator.GetFiles(FileIndexerMainForm.LoadedDirectory);

            try
            {
                if (FileNameTextBox.Text != string.Empty)
                {
                    var fileName = FileNameTextBox.Text.ToLower();

                    extractedFiles = extractedFiles.Where(f => f.Name.ToLower().Contains(fileName)).ToList();
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
                        extractedFiles = extractedFiles.Where(f => f.Size <= size).ToList();
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
                        extractedFiles = extractedFiles.Where(f => f.Size >= size).ToList();
                    }
                }
                if (DateModifiedTextBox.Text != string.Empty)
                {
                    var date = DateTime.Parse(DateModifiedTextBox.Text);

                    extractedFiles = extractedFiles.Where(f => f.LastModified == date).ToList();
                }
                if (FileExtensionTextBox.Text != string.Empty)
                {
                    var extension = FileExtensionTextBox.Text;

                    extractedFiles = extractedFiles.Where(f => f.Extension == extension).ToList();
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
            mainForm.LoadFoundFiles(extractedFiles);

            // Clear the foundFiles list
            extractedFiles.Clear();
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
