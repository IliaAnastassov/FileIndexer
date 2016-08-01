namespace FileIndexerApplication.Models
{
    using System;
    using System.Drawing;

    public class FIFile
    {
        private string fileName;
        private string filePath;
        private string fileExtension;
        private DateTime lastModified;
        private int fileSize;
        private Image fileImage;

        public FIFile(string name, string path, string extension, DateTime lastModified, int size, Image image)
        {
            this.fileName = name;
            this.filePath = path;
            this.fileExtension = extension;
            this.lastModified = lastModified;
            this.fileSize = size;
            this.fileImage = image;
        }

        public Image FileImage
        {
            get { return fileImage; }
            set { fileImage = value; }
        }

        public int FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        public DateTime LastModified
        {
            get { return lastModified; }
            set { lastModified = value; }
        }

        public string FileExtension
        {
            get { return fileExtension; }
            set { fileExtension = value; }
        }

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

    }
}
