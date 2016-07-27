namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;

    [Serializable]
    public class TreeNode<T>
    {
        private readonly T value;
        private readonly List<TreeNode<T>> nodes = new List<TreeNode<T>>();
        private readonly List<FileInfo> leafs = new List<FileInfo>();

        public TreeNode(T value)
        {
            this.value = value;
        }

        public TreeNode<T> this[int index]
        {
            get { return nodes[index]; }
        }

        public TreeNode<T> Parent { get; private set; }

        public T Value { get { return value; } }

        public ReadOnlyCollection<TreeNode<T>> Nodes { get { return nodes.AsReadOnly(); } }

        public void AddNode(T value)
        {
            var node = new TreeNode<T>(value) { Parent = this };
            nodes.Add(node);
        }

        public void RemoveNode(TreeNode<T> node)
        {
            nodes.Remove(node);
        }

        public void AddLeaf(FileInfo file)
        {
            leafs.Add(file);
        }

        private void RemoveLeaf(FileInfo file)
        {
            leafs.Remove(file);
        }

        public IEnumerable<T> Flatten()
        {
            return new[] { Value }.Union(nodes.SelectMany(x => x.Flatten()));
        }
    }
}
