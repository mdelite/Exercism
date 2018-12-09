using System;
using System.Collections;
using System.Collections.Generic;

public class Deque<T>
{
    Node Head = new Node();
    public void Push(T value) => Head.Insert(value);

    public T Pop() => Head.Prev.Remove();

    public void Unshift(T value)
    {
        throw new NotImplementedException();
    }

    public T Shift()
    {
        throw new NotImplementedException();
    }

    public class Node
    {
        public T Value;
        public Node Next;
        public Node Prev;

        public Node()
        {
            Next = this;
            Prev = this;
        }

        internal void Insert(T value)
        {
            Prev = Prev.Next = new Node{ Value = value, Next = this, Prev = this.Prev };
        }

        internal T Remove()
        {
            Next.Prev = Prev;
            Prev.Next = Next;
            return Value;
        }
    }
}

