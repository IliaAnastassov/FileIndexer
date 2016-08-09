namespace FileIndexerApplication.Factories
{
    using System.Collections.Generic;
    using Contracts;
    using Models;

    public class FileGenerator
    {
        public static IList<FIFile> GetFiles(IFIDirectory dir)
        {
            var files = new List<FIFile>();

            ExtractFiles(dir, files);

            return files;
        }

        private static void ExtractFiles(IFIDirectory dir, IList<FIFile> files)
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
