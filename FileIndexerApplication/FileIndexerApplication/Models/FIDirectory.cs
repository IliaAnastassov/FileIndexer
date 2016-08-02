namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class FIDirectory : IFIDirectory
    {
        private List<FIDirectory> subDirs;
        private List<FIFile> files;
        private FIDirectory parent;
        private string path;
        private string icon;
        private string name;
        private bool isLive;
        private DateTime lastModified;

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="path"></param>
        public FIDirectory(string path, string name, DateTime lastModified)
        {
            this.path = path;
            this.name = name;
            this.lastModified = lastModified;
            isLive = false;
        }

        public DateTime LastModified
        {
            get { return lastModified; }
            set { lastModified = value; }
        }

        public bool IsLive
        {
            get { return isLive; }
            set { isLive = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public FIDirectory Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public List<FIFile> Files
        {
            get { return files; }
            set { files = value; }
        }

        public List<FIDirectory> SubDirs
        {
            get { return subDirs; }
            set { subDirs = value; }
        }

        public void AddSubDir(FIDirectory subDir)
        {
            this.subDirs.Add(subDir);
            subDir.Parent = this;
        }

        public void AddFile(FIFile file)
        {
            this.Files.Add(file);
        }
    }
}
