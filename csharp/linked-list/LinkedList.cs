using System;

public class Deque<T>
{
    private Node _head = new Node();
    
    public void Push(T value) => _head.Insert(value);

    public T Pop() => _head.Prev.Remove();

    public void Unshift(T value) => _head.Next.Insert(value);

    public T Shift() => _head.Next.Remove();

    private class Node
    {
        public T Value;
        public Node Next;
        public Node Prev;

        public Node() => Next = Prev = this;

        public void Insert(T value) => Prev = Prev.Next = new Node { Value = value, Next = this, Prev = this.Prev };

        public T Remove()
        {
            Next.Prev = Prev;
            Prev.Next = Next;
            return Value;
        }
    }
}

