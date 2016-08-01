namespace FileIndexerApplication.Contracts
{
    using Models;

    public interface IFIDirectory
    {
        void AddSubDir(FIDirectory subDir);

        void AddFile(FIFile file);
    }
}
