using LinkedLists.Core.Interfaces.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Core.Implementation.Nodes
{
    public class SimpleLinkedNode<T> : ISimpleLinkedNode<T>
    {
        public T Value { get; set; }
        public ISimpleLinkedNode<T> Next { get; set; }

        public SimpleLinkedNode(T value)
        {
            this.Value = value;
        }
    }
}
