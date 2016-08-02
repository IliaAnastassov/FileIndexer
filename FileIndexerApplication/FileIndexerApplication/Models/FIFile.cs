namespace FileIndexerApplication.Models
{
    using System;
    using System.Drawing;

    public class FIFile
    {
        private string name;
        private string path;
        private string extension;
        private DateTime lastModified;
        private int size;
        private string icon;

        public FIFile(string name, string path, string extension, DateTime lastModified, int size, string icon)
        {
            this.name = name;
            this.path = path;
            this.extension = extension;
            this.lastModified = lastModified;
            this.size = size;
            this.icon = icon;
        }

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public int Size
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
