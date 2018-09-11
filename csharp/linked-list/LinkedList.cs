using System;
using System.Collections;
using System.Collections.Generic;

public class Deque<T>
{
    private class Node
    {
        public T Value;
        public Node Next;
        public Node Previous;

        public Node()
        {
            Next = this;
            Previous = this;
        }

        internal void Append(T value)
        {
            throw new NotImplementedException();
        }

        internal T Remove()
        {
            throw new NotImplementedException();
        }
    }

    Node node = new Node();

    public Deque() => throw new NotImplementedException();

    public void Push(T value) => node.Next.Append(value);

    public T Pop() => node.Next.Remove();

    public void Unshift(T value) => throw new NotImplementedException();

    public T Shift() => throw new NotImplementedException();
}