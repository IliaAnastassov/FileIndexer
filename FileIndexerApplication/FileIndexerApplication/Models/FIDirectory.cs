﻿namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    using Contracts;

    [Serializable]
    public class FIDirectory : IFIDirectory, ISerializable
    {
        private List<FIDirectory> subdirs = new List<FIDirectory>();
        private List<FIFile> files = new List<FIFile>();
        private FIDirectory parent;
        private string path;
        private int imageIndex;
        private string name;
        private bool isLive;
        private DateTime lastModified;

        /// <summary>
        /// Initializes a new instance of the <see cref="FIDirectory" /> class
        /// </summary>
        public FIDirectory()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FIDirectory" /> class
        /// </summary>
        /// <param name="path">The path of the directory</param>
        /// <param name="name">The name of the directory</param>
        /// <param name="lastModified">The last modified date of the directory</param>
        public FIDirectory(string path, string name, DateTime lastModified)
        {
            this.path = path;
            this.name = name;
            this.lastModified = lastModified;
            this.ImageIndex = 0;
            isLive = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FIDirectory" /> class to be deserialized
        /// </summary>
        /// <param name="info">Information to be extracted during the deserialization process</param>
        /// <param name="context">The source and destination of the deserialized stream</param>
        public FIDirectory(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("Serializable info cannot be null");
            }

            subdirs = (List<FIDirectory>)info.GetValue("subdirs", typeof(List<FIDirectory>));
            files = (List<FIFile>)info.GetValue("files", typeof(List<FIFile>));
            parent = (FIDirectory)info.GetValue("parent", typeof(FIDirectory));
            path = (string)info.GetValue("path", typeof(string));
            imageIndex = (int)info.GetValue("imageIndex", typeof(int));
            name = (string)info.GetValue("name", typeof(string));
            isLive = (bool)info.GetValue("isLive", typeof(bool));
            lastModified = (DateTime)info.GetValue("lastModified", typeof(DateTime));
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

        public int ImageIndex
        {
            get { return imageIndex; }
            set { imageIndex = value; }
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
            private set { files = value; }
        }

        public List<FIDirectory> Subdirs
        {
            get { return subdirs; }
            private set { subdirs = value; }
        }

        public void AddSubdirectory(FIDirectory subDir)
        {
            this.subdirs.Add(subDir);
            subDir.Parent = this;
        }

        public void AddFile(FIFile file)
        {
            this.Files.Add(file);
        }

        /// <summary>
        /// Serialization Method
        /// </summary>
        /// <param name="info">The information to be serialized</param>
        /// <param name="context">The source and destination of the serialized stream</param>
        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("Serializable info cannot be null");
            }

            info.AddValue("subdirs", subdirs);
            info.AddValue("files", files);
            info.AddValue("parent", parent);
            info.AddValue("path", path);
            info.AddValue("imageIndex", ImageIndex);
            info.AddValue("name", name);
            info.AddValue("isLive", isLive);
            info.AddValue("lastModified", lastModified);
        }
    }
}