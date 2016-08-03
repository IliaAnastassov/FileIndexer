﻿namespace FileIndexerApplication.Models
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;

    public class FileIndexer
    {
        public static void SaveTree(FIDirectory tree, string filename)
        {
            using (Stream file = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();

                try
                {
                    bf.Serialize(file, tree);
                }
                catch (SerializationException ex)
                {
                    MessageBox.Show("Failed to serialize. Reason: " + ex.Message);
                }
            }
        }

        public static void LoadTree(FIDirectory tree, string filename)
        {
            using (Stream file = File.Open(filename, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();

                try
                {
                    tree = bf.Deserialize(file) as FIDirectory;
                }
                catch (SerializationException ex)
                {
                    MessageBox.Show("Failed to deserialize. Reason: " + ex.Message);
                }
            }
        }

        public static void ExtractItems(DirectoryInfo dir, FIDirectory fiDir)
        {
            // Extract needed information about the containing files of the DirectoryInfo object
            // and store it in the FIDirectory object
            foreach (var file in dir.GetFiles())
            {
                if (file.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    continue;
                }

                if (file.Exists)
                {
                    var fiFile = new FIFile(file.Name, file.FullName, file.Extension, file.LastWriteTime, file.Length);
                    fiDir.AddFile(fiFile);
                }
            }

            try
            {
                // Recursively extract needed information about all the subdirectories and their
                // subdirectories of the Directoryinfo object and save it to the FIDirectory object
                foreach (var subdir in dir.GetDirectories())
                {
                    if (subdir.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        continue;
                    }

                    var fiSubdir = new FIDirectory(subdir.FullName, subdir.Name, subdir.LastWriteTime);
                    fiDir.AddSubdirectory(fiSubdir);

                    ExtractItems(subdir, fiSubdir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
