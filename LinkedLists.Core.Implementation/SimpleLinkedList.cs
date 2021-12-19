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
        protected ISimpleLinkedNode<T> Head;
        protected ISimpleLinkedNode<T> Tail;
        protected int NodesCount;

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
                Tail = node;
            }
            else
            {
                node.Next = Head;
            }
            Head = node;

            NodesCount++;
        }

        public bool RemoveOne(T value)
        {
            var current = Head;
            ISimpleLinkedNode<T> previous = null;

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
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public bool RemoveOne(Func<T, bool> filter)
        {
            var current = Head;
            ISimpleLinkedNode<T> previous = null;

            while (current != null)
            {
                if (filter(current.Value))
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
            ISimpleLinkedNode<T> previousAcceptable = null;

            var removedCount = 0;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previousAcceptable == null)
                    {
                        Head = Head.Next;

                        if (Head == null)
                            Tail = null;
                    }
                    else
                    {
                        previousAcceptable.Next = current.Next;

                        if (current.Next == null)
                            Tail = previousAcceptable;
                    }

                    NodesCount--;
                    removedCount++;
                }
                else
                    previousAcceptable = current;

                current = current.Next;
            }

            return removedCount;
        }

        public int RemoveAll(Func<T, bool> filter)
        {
            var current = Head;
            ISimpleLinkedNode<T> previousAcceptable = null;

            var removedCount = 0;

            while (current != null)
            {
                if (filter(current.Value))
                {
                    if (previousAcceptable == null)
                    {
                        Head = Head.Next;

                        if (Head == null)
                            Tail = null;
                    }
                    else
                    {
                        previousAcceptable.Next = current.Next;

                        if (current.Next == null)
                            Tail = previousAcceptable;
                    }

                    NodesCount--;
                    removedCount++;
                } 
                else
                    previousAcceptable = current;


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

        public ISimpleLinkedList<T> Where(Func<T, bool> filter)
        {
            var list = new SimpleLinkedList<T>();

            if (Head == null)
                return list;

            var current = Head;
            while (current != null)
            {
                if (filter(current.Value))
                    list.Add(current.Value);

                current = current.Next;
            }

            return list;
        }

        public T FirstOrDefault()
        {
            if (Head == null)
                return default;

            return Head.Value;
        }

        public T FirstOrDefault(Func<T, bool> filter)
        {
            if (Head == null)
                return default;

            var current = Head;

            while (current != null)
            {
                if (filter(current.Value))
                    return current.Value;

                current = current.Next;
            }

            return default;
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

        public bool Any(Func<T, bool> filter)
        {
            if (Head == null)
                return false;

            var current = Head;

            while (current != null)
            {
                if (filter(current.Value))
                    return true;

                current = current.Next;
            }

            return false;
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
