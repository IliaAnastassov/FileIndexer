namespace FileIndexerApplication.Models
{
    using System;
    using System.Drawing;

    [Serializable]
    public class FIFile
    {
        private string name;
        private string path;
        private string extension;
        private DateTime lastModified;
        private long size;
        private int imageIndex;

        public FIFile(string name, string path, string extension, DateTime lastModified, long size)
        {
            this.name = name;
            this.path = path;
            this.extension = extension;
            this.lastModified = lastModified;
            this.size = size;
            this.imageIndex = 1;
        }

        public int ImageIndex
        {
            get { return imageIndex; }
            set { imageIndex = value; }
        }

        public long Size
        {
            get { return size; }
            set { size = value; }
        }

        public DateTime LastModified
        {
            get { return lastModified; }
            set { lastModified = value; }
        }

        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
