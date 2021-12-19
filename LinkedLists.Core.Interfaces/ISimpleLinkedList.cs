using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Core.Interfaces
{
    public interface ISimpleLinkedList<T> : IEnumerable<T>
    {
        public void Add(T value);
        public void AddFirst(T value);
        public void AddRange(IEnumerable<T> values);
        public bool RemoveOne(T value);
        public bool RemoveOne(Func<T, bool> filter);
        public int RemoveAll(T value);
        public int RemoveAll(Func<T, bool> filter);
        public void Concat(ISimpleLinkedList<T> secondList);
        public ISimpleLinkedList<T> Where(Func<T, bool> filter);
        public T FirstOrDefault();
        public T FirstOrDefault(Func<T, bool> filter);
        public T LastOrDefault();
        public int Length();
        public bool Any();
        public bool Any(Func<T, bool> filter);
    }
}
