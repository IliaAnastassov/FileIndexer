namespace FileIndexerApplication.Factories
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Models;

    public class FileGenerator
    {
        public static List<FIFile> GetFiles(FIDirectory dir)
        {
            var files = new List<FIFile>();

            ExtractFiles(dir, files);

            return files;
        }

        private static void ExtractFiles(FIDirectory dir, List<FIFile> files)
        {
            foreach (var file in dir.Files)
            {
                files.Add(file);
            }

            foreach (var subdir in dir.Subdirs)
            {
                ExtractFiles(subdir, files);
            }
        }
    }
}
