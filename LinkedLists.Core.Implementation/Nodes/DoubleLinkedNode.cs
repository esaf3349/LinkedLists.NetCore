using LinkedLists.Core.Interfaces.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Core.Implementation.Nodes
{
    public class DoubleLinkedNode<T> : SimpleLinkedNode<T>, IDoubleLinkedNode<T>
    {
        public IDoubleLinkedNode<T> Previous { get; set; }

        public DoubleLinkedNode(T value) : base(value) { }
    }
}
