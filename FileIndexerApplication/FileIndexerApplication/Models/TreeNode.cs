namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;

    public class TreeNode<T>
    {
        private readonly T value;
        private readonly List<TreeNode<T>> childNodes = new List<TreeNode<T>>();
        private readonly List<FileInfo> childItems = new List<FileInfo>();

        public TreeNode(T value)
        {
            this.value = value;
        }

        public TreeNode<T> this[int index]
        {
            get { return childNodes[index]; }
        }

        public TreeNode<T> Parent { get; private set; }

        public T Value { get { return value; } }

        public ReadOnlyCollection<TreeNode<T>> ChildNodes { get { return childNodes.AsReadOnly(); } }

        public void AddChildNode(T value)
        {
            var node = new TreeNode<T>(value) { Parent = this };
            childNodes.Add(node);
        }

        public void RemoveChildNode(TreeNode<T> node)
        {
            childNodes.Remove(node);
        }

        public void AddChildItem(FileInfo file)
        {
            childItems.Add(file);
        }

        private void RemoveChildItem(FileInfo file)
        {
            childItems.Remove(file);
        }

        public IEnumerable<T> Flatten()
        {
            return new[] { Value }.Union(childNodes.SelectMany(x => x.Flatten()));
        }
    }
}
