namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class FileSearcher : IFileSearcher
    {
        public IList<FIFile> SearchByName(IList<FIFile> files, string name)
            => files.Where(f => f.Name.ToLower().Contains(name)).ToList();

        public IList<FIFile> SearchByMaxSize(IList<FIFile> files, long size)
            => files.Where(f => f.Size <= size).ToList();

        public IList<FIFile> SearchByMinSize(IList<FIFile> files, long size)
            => files.Where(f => f.Size >= size).ToList();

        public IList<FIFile> SearchByExtension(IList<FIFile> files, string extension)
            => files.Where(f => f.Extension == extension).ToList();

        public IList<FIFile> SearchByDate(IList<FIFile> files, DateTime date)
            => files.Where(f => f.LastModified == date).ToList();
    }
}
