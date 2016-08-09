namespace FileIndexerApplication.Contracts
{
    using Models;
    using System.Collections.Generic;

    public interface IFIDirectory
    {
        void AddSubdirectory(FIDirectory subDir);

        void AddFile(FIFile file);

        List<FIFile> Files { get; }

        List<FIDirectory> Subdirs { get; }
    }
}
