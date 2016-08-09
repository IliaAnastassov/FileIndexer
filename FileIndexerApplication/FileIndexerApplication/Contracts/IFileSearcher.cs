namespace FileIndexerApplication.Contracts
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface IFileSearcher
    {
        IList<FIFile> SearchFiles(IList<FIFile> files, string name, string maxSize, string minSize, string date, string extension);
    }
}
