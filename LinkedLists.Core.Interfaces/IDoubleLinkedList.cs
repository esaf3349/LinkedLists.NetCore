using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Core.Interfaces
{
    public interface IDoubleLinkedList<T> : ISimpleLinkedList<T>
    {
        public T LastOrDefault(Func<T, bool> filter);
        public IEnumerable<T> ToReversedEnumerable();
    }
}
