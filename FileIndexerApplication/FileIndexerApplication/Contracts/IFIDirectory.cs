namespace FileIndexerApplication.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IFIDirectory
    {
        List<FIDirectory> Subdirs { get; }

        List<FIFile> Files { get; }

        void AddSubdirectory(FIDirectory subDir);

        void AddFile(FIFile file);
    }
}
