namespace FileIndexerApplication.Models
{
    using System;

    public class FileIndex
    {
        private string fileName;
        private long fileSize;
        private string fileLocation;

        public FileIndex(string fileName, long fileSize, string fileLocation)
        {
            this.FileName = fileName;
            this.FileSize = fileSize;
            this.FileLocation = fileLocation;
        }

        public string FileLocation
        {
            get { return fileLocation; }
            set { fileLocation = value; }
        }

        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

    }
}
