using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Core.Interfaces.Nodes
{
    public interface IDoubleLinkedNode<T> : ISimpleLinkedNode<T>
    {
        public IDoubleLinkedNode<T> Previous { get; set; }
    }
}
