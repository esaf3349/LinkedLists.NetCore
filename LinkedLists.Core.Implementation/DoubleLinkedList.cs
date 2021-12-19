using LinkedLists.Core.Implementation.Nodes;
using LinkedLists.Core.Interfaces;
using LinkedLists.Core.Interfaces.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Core.Implementation
{
    public class DoubleLinkedList<T> : IDoubleLinkedList<T>
    {
        protected IDoubleLinkedNode<T> Head;
        protected IDoubleLinkedNode<T> Tail;
        protected int NodesCount;

        public void Add(T value)
        {
            var node = new DoubleLinkedNode<T>(value);

            if (Head == null)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;

            NodesCount++;
        }

        public void AddFirst(T value)
        {
            var node = new DoubleLinkedNode<T>(value);

            if (Head == null)
            {
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head.Previous = node;
            }
            Head = node;

            NodesCount++;
        }

        public void AddRange(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                Add(value);
            }
        }

        public bool RemoveOne(T value)
        {
            var current = Head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current.Previous == null)
                    {
                        Head = (IDoubleLinkedNode<T>)Head.Next;

                        if (Head == null)
                            Tail = null;
                        else
                            Head.Previous = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        var next = (IDoubleLinkedNode<T>)current.Next;
                        next.Previous = current.Previous;

                        if (current.Next == null)
                            Tail = current.Previous;
                    }

                    NodesCount--;
                    return true;
                }

                current = (IDoubleLinkedNode<T>)current.Next;
            }

            return false;
        }

        public bool RemoveOne(Func<T, bool> filter)
        {
            var current = Head;

            while (current != null)
            {
                if (filter(current.Value))
                {
                    if (current.Previous == null)
                    {
                        Head = (IDoubleLinkedNode<T>)Head.Next;

                        if (Head == null)
                            Tail = null;
                        else
                            Head.Previous = null;
                    }
                    else
                    {
                        var next = (IDoubleLinkedNode<T>)current.Next;
                        current.Previous.Next = next;
                        next.Previous = current.Previous;

                        if (current.Next == null)
                            Tail = current.Previous;
                    }

                    NodesCount--;
                    return true;
                }

                current = (IDoubleLinkedNode<T>)current.Next;
            }

            return false;
        }

        public int RemoveAll(T value)
        {
            var current = Head;
            IDoubleLinkedNode<T> previousAcceptable = null;

            var removedCount = 0;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previousAcceptable == null)
                    {
                        Head = (IDoubleLinkedNode<T>)Head.Next;

                        if (Head == null)
                            Tail = null;
                        else
                            Head.Previous = null;
                    }
                    else
                    {
                        var next = (IDoubleLinkedNode<T>)current.Next;
                        previousAcceptable.Next = next;

                        if (current.Next == null)
                            Tail = previousAcceptable;
                        else
                            next.Previous = previousAcceptable;
                    }

                    NodesCount--;
                    removedCount++;
                }
                else
                    previousAcceptable = current;

                current = (IDoubleLinkedNode<T>)current.Next;
            }

            return removedCount;
        }

        public int RemoveAll(Func<T, bool> filter)
        {
            var current = Head;
            IDoubleLinkedNode<T> previousAcceptable = null;

            var removedCount = 0;

            while (current != null)
            {
                if (filter(current.Value))
                {
                    if (previousAcceptable == null)
                    {
                        Head = (IDoubleLinkedNode<T>)Head.Next;

                        if (Head == null)
                            Tail = null;
                        else
                            Head.Previous = null;
                    }
                    else
                    {
                        var next = (IDoubleLinkedNode<T>)current.Next;
                        previousAcceptable.Next = next;

                        if (next == null)
                            Tail = previousAcceptable;
                        else
                            next.Previous = previousAcceptable;
                    }

                    NodesCount--;
                    removedCount++;
                }
                else
                    previousAcceptable = current;

                current = (IDoubleLinkedNode<T>)current.Next;
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
            var list = new DoubleLinkedList<T>();

            if (Head == null)
                return list;

            var current = Head;
            while (current != null)
            {
                if (filter(current.Value))
                    list.Add(current.Value);

                current = (IDoubleLinkedNode<T>)current.Next;
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

                current = (IDoubleLinkedNode<T>)current.Next;
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

                current = (IDoubleLinkedNode<T>)current.Next;
            }

            return false;
        }

        public T LastOrDefault(Func<T, bool> filter)
        {
            if (Tail == null)
                return default;

            var current = Tail;

            while (current != null)
            {
                if (filter(current.Value))
                    return current.Value;

                current = current.Previous;
            }

            return default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            IDoubleLinkedNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = (IDoubleLinkedNode<T>)current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
