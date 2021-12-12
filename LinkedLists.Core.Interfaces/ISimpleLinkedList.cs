using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Core.Interfaces
{
    public interface ISimpleLinkedList<T> : IEnumerable<T>
    {
        public void Add(T value);
        public void AddFirst(T value);
        public bool RemoveOne(T value);
        public int RemoveAll(T value);
        public void Concat(ISimpleLinkedList<T> secondList);
        public T FirstOrDefault();
        public T LastOrDefault();
        public int Length();
        public bool Any();
    }
}
