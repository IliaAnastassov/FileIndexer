namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;

    public class FileSearcher
    {
        public static void SearchByname(FIDirectory dir, string fileName, List<FIFile> foundFiles)
        {
            foreach (var file in dir.Files)
            {
                if (file.Name == fileName)
                {
                    foundFiles.Add(file);
                }
            }

            foreach (var subdir in dir.Subdirs)
            {
                SearchByname(subdir, fileName, foundFiles);
            }
        }
    }
}
