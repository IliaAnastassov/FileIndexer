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
        private string icon;

        public FIFile(string name, string path, string extension, DateTime lastModified, int size, string icon)
        {
            this.fileName = name;
            this.filePath = path;
            this.fileExtension = extension;
            this.lastModified = lastModified;
            this.fileSize = size;
            this.icon = icon;
        }

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
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
