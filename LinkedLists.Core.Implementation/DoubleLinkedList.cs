using LinkedLists.Core.Implementation.Nodes;
using LinkedLists.Core.Interfaces;
using LinkedLists.Core.Interfaces.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Core.Implementation
{
    public class DoubleLinkedList<T> : SimpleLinkedList<T>, IDoubleLinkedList<T>
    {
        protected new IDoubleLinkedNode<T> Head;
        protected new IDoubleLinkedNode<T> Tail;

        public override void Add(T value)
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

        public override void AddFirst(T value)
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

        public override bool RemoveOne(T value)
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

        public override bool RemoveOne(Func<T, bool> filter)
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

        public override int RemoveAll(T value)
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
                        next.Previous = previousAcceptable;

                        if (current.Next == null)
                            Tail = previousAcceptable;
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

        public override int RemoveAll(Func<T, bool> filter)
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
                        next.Previous = previousAcceptable;

                        if (current.Next == null)
                            Tail = previousAcceptable;
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
    }
}
