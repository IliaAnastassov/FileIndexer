namespace FileIndexerApplication.Contracts
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface IFileSearcher
    {
        IList<FIFile> SearchByName(IList<FIFile> files, string name);

        IList<FIFile> SearchByMaxSize(IList<FIFile> files, long size);

        IList<FIFile> SearchByMinSize(IList<FIFile> files, long size);

        IList<FIFile> SearchByDate(IList<FIFile> files, DateTime date);

        IList<FIFile> SearchByExtension(IList<FIFile> files, string extension);
    }
}
