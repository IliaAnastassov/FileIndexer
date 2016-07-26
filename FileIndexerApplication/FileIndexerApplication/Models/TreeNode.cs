namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class TreeNode<T>
    {
        private readonly T value;
        private readonly List<TreeNode<T>> childNodes = new List<TreeNode<T>>();

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

        // TODO: Why return a value?
        public TreeNode<T> AddChildNode(T value)
        {
            var node = new TreeNode<T>(value) { Parent = this };
            childNodes.Add(node);
            return node;
        }

        // TODO: Why return a bool?
        public bool RemoveChildNode(TreeNode<T> node)
        {
            return childNodes.Remove(node);
        }

        public IEnumerable<T> Flatten()
        {
            return new[] { Value }.Union(childNodes.SelectMany(x => x.Flatten()));
        }
    }
}
