namespace FileIndexerApplication.Contracts
{
    using Models;

    public interface IFIDirectory
    {
        void AddSubdirectory(FIDirectory subDir);

        void AddFile(FIFile file);
    }
}
