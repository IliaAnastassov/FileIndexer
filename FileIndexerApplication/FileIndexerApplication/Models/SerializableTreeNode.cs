namespace FileIndexerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Security;
    using System.Security.Permissions;

    [Serializable]
    public class SerializableTreeNode<T> : ISerializable
    {
        private readonly T value;
        private readonly List<SerializableTreeNode<T>> childNodes = new List<SerializableTreeNode<T>>();

        public SerializableTreeNode(T value)
        {
            this.value = value;
        }

        public SerializableTreeNode<T> this[int index]
        {
            get { return childNodes[index]; }
        }

        public SerializableTreeNode<T> Parent { get; private set; }

        public T Value { get { return value; } }

        public ReadOnlyCollection<SerializableTreeNode<T>> Nodes { get { return childNodes.AsReadOnly(); } }

        public void AddChildNode(T value)
        {
            var node = new SerializableTreeNode<T>(value) { Parent = this };
            childNodes.Add(node);
        }

        public void RemoveChildNode(SerializableTreeNode<T> node)
        {
            childNodes.Remove(node);
        }

        public IEnumerable<T> Flatten()
        {
            return new[] { Value }.Union(childNodes.SelectMany(x => x.Flatten()));
        }

        // Serialization method
        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("Value", value);
            info.AddValue("Nodes", childNodes);
            info.AddValue("Parent", Parent);
        }

        // Deserialization Constructor
        public SerializableTreeNode(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            value = (dynamic)info.GetValue("Value", typeof(object));
            childNodes = (dynamic)info.GetValue("Nodes", typeof(object));
            Parent = (dynamic)info.GetValue("Parent", typeof(object));
        }
    }
}
