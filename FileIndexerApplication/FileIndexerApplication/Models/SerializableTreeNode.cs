namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;

    [Serializable]
    public class SerializableTreeNode<T> : ISerializable
    {
        private readonly T value;
        private readonly List<SerializableTreeNode<T>> nodes = new List<SerializableTreeNode<T>>();

        public SerializableTreeNode(T value)
        {
            this.value = value;
        }

        public SerializableTreeNode<T> this[int index]
        {
            get { return nodes[index]; }
        }

        public SerializableTreeNode<T> Parent { get; private set; }

        public T Value { get { return value; } }

        public ReadOnlyCollection<SerializableTreeNode<T>> Nodes { get { return nodes.AsReadOnly(); } }

        public void AddNode(T value)
        {
            var node = new SerializableTreeNode<T>(value) { Parent = this };
            nodes.Add(node);
        }

        public void RemoveNode(SerializableTreeNode<T> node)
        {
            nodes.Remove(node);
        }

        public IEnumerable<T> Flatten()
        {
            return new[] { Value }.Union(nodes.SelectMany(x => x.Flatten()));
        }

        // Serialization method
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Value", value);
            info.AddValue("Nodes", nodes);
            info.AddValue("Parent", Parent);
        }

        // Deserialization Constructor
        public SerializableTreeNode(SerializationInfo info, StreamingContext context)
        {
            value = (dynamic)info.GetValue("Value", typeof(object));
            nodes = (dynamic)info.GetValue("Nodes", typeof(object));
            Parent = (dynamic)info.GetValue("Parent", typeof(object));
        }
    }
}
