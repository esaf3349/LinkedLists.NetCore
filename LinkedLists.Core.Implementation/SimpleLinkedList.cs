using LinkedLists.Core.Implementation.Nodes;
using LinkedLists.Core.Interfaces;
using LinkedLists.Core.Interfaces.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Core.Implementation
{
    public class SimpleLinkedList<T> : ISimpleLinkedList<T>
    {
        private ISimpleLinkedNode<T> Head;
        private ISimpleLinkedNode<T> Tail;
        private int NodesCount;

        public void Add(T value)
        {
            var node = new SimpleLinkedNode<T>(value);

            if (Head == null)
                Head = node;
            else
                Tail.Next = node;

            Tail = node;

            NodesCount++;
        }

        public void AddFirst(T value)
        {
            var node = new SimpleLinkedNode<T>(value);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }

            NodesCount++;
        }

        public bool RemoveOne(T value)
        {
            var current = Head;
            ISimpleLinkedNode<T> previous = null;

            while (current != null)
            {
                var currentValue = current.Value;
                //var some = current.Value.Equals(value);
                if (currentValue.Equals(value))
                {
                    if (previous == null)
                    {
                        Head = Head.Next;

                        if (Head == null)
                            Tail = null;
                    }
                    else
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            Tail = previous;
                    }

                    NodesCount--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public int RemoveAll(T value)
        {
            var current = Head;
            ISimpleLinkedNode<T> previous = null;

            var removedCount = 0;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous == null)
                    {
                        Head = Head.Next;

                        if (Head == null)
                            Tail = null;
                    }
                    else
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            Tail = previous;
                    }

                    NodesCount--;
                    removedCount++;
                }

                previous = current;
                current = current.Next;
            }

            return removedCount;
        }

        public void Concat(ISimpleLinkedList<T> secondList)
        {
            if (!secondList.Any())
                return;

            foreach (var value in secondList)
            {
                Add(value);
            }
        }

        public T FirstOrDefault()
        {
            if (Head == null)
                return default;

            return Head.Value;
        }

        public T LastOrDefault()
        {
            if (Tail == null)
                return default;

            return Tail.Value;
        }

        public int Length()
        {
            return NodesCount;
        }

        public bool Any()
        {
            return Head != null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ISimpleLinkedNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
