namespace FileIndexerApplication.Contracts
{
    using System.Windows.Forms;

    public interface IIndexTree
    {
        void SaveIndexTree(TreeView tree, string filename);

        void LoadIndexTree(TreeView tree, string filename);
    }
}
