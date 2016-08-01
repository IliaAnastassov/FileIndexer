﻿namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class FIDirectory : IFIDirectory
    {
        private List<FIDirectory> subDirs;
        private List<FIFile> files;
        private FIDirectory parent;
        private string directoryPath;

        public FIDirectory(string path)
        {
            this.directoryPath = path;
        }

        public string DirectoryPath
        {
            get { return directoryPath; }
            set { directoryPath = value; }
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
