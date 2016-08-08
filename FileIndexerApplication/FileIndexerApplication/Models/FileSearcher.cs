namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FileSearcher
    {
        public static void SearchByName(FIDirectory dir, string fileName, List<FIFile> foundFiles)
        {
            foreach (var file in dir.Files)
            {
                if (file.Name.ToLower().Contains(fileName))
                {
                    foundFiles.Add(file);
                }
            }

            foreach (var subdir in dir.Subdirs)
            {
                SearchByName(subdir, fileName, foundFiles);
            }
        }

        public static void SearchByMaxSize(FIDirectory dir, int fileSize, List<FIFile> foundFiles)
        {
            foreach (var file in dir.Files)
            {
                if (file.Size <= fileSize)
                {
                    foundFiles.Add(file);
                }
            }

            foreach (var subdir in dir.Subdirs)
            {
                SearchByMaxSize(subdir, fileSize, foundFiles);
            }
        }

        public static void SearchByMinSize(FIDirectory dir, int fileSize, List<FIFile> foundFiles)
        {
            foreach (var file in dir.Files)
            {
                if (file.Size >= fileSize)
                {
                    foundFiles.Add(file);
                }
            }

            foreach (var subdir in dir.Subdirs)
            {
                SearchByMinSize(subdir, fileSize, foundFiles);
            }
        }

        public static void SearchByDateModified(FIDirectory dir, DateTime date, List<FIFile> foundFiles)
        {
            foreach (var file in dir.Files)
            {
                if (file.LastModified == date)
                {
                    foundFiles.Add(file);
                }
            }

            foreach (var subdir in dir.Subdirs)
            {
                SearchByDateModified(subdir, date, foundFiles);
            }
        }

        public static void SearchByFileExtension(FIDirectory dir, string fileExtension, List<FIFile> foundFiles)
        {
            foreach (var file in dir.Files)
            {
                var extension = file.Name.Split('.').ToArray()[1];

                if (extension == fileExtension)
                {
                    foundFiles.Add(file);
                }
            }

            foreach (var subdir in dir.Subdirs)
            {
                SearchByFileExtension(subdir, fileExtension, foundFiles);
            }
        }
    }
}
