using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Core.Interfaces.Nodes
{
    public interface ISimpleLinkedNode<T>
    {
        public T Value { get; set; }
        public ISimpleLinkedNode<T> Next { get; set; }
    }
}
