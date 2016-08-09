namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class FileSearcher : IFileSearcher
    {
        public IList<FIFile> SearchFiles(IList<FIFile> files, string name, string maxSize, string minSize, string date, string extension)
        {
            if (name != string.Empty)
            {
                files = SearchByName(files, name);
            }

            if (maxSize != string.Empty)
            {
                var size = EvaluateSize(maxSize);
                files = SearchByMaxSize(files, size);
            }

            if (minSize != string.Empty)
            {
                var size = EvaluateSize(minSize);
                files = SearchByMinSize(files, size);
            }

            if (date != string.Empty)
            {
                files = SearchByDate(files, DateTime.Parse(date));
            }

            if (extension != string.Empty)
            {
                files = SearchByExtension(files, extension);
            }

            return files;
        }

        private IList<FIFile> SearchByName(IList<FIFile> files, string name)
            => files.Where(f => f.Name.ToLower().Contains(name)).ToList();

        private IList<FIFile> SearchByMaxSize(IList<FIFile> files, long size)
            => files.Where(f => f.Size <= size).ToList();

        private IList<FIFile> SearchByMinSize(IList<FIFile> files, long size)
            => files.Where(f => f.Size >= size).ToList();

        private IList<FIFile> SearchByExtension(IList<FIFile> files, string extension)
            => files.Where(f => f.Extension == extension).ToList();

        private IList<FIFile> SearchByDate(IList<FIFile> files, DateTime date)
            => files.Where(f => f.LastModified == date).ToList();

        private long EvaluateSize(string inputStr)
        {
            long size;
            string[] input;

            try
            {
                input = inputStr.Split();

                // Check if input is valid
                if (input.Length < 2)
                {
                    throw new FormatException();
                }

                size = long.Parse(input[0]);
            }
            catch (Exception)
            {
                throw new FormatException();
            }

            // Check if size is valid
            if (size < 0)
            {
                throw new ArgumentException();
            }

            if (input[1].ToUpper() == "KB")
            {
                size *= 1000;
            }
            else if (input[1].ToUpper() == "MB")
            {
                size *= 1000000;
            }
            else if (input[1].ToUpper() == "GB")
            {
                size *= 1000000000;
            }
            else
            {
                throw new ArgumentException();
            }

            return size;
        }
    }
}
