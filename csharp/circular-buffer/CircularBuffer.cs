using System;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private Queue<T> queue;
    private int capacity;

    public CircularBuffer(int capacity)
    {
        this.capacity = capacity;
        queue = new Queue<T>(capacity);
    }

    public T Read()
    {
        if (queue.Peek() == null)
        {
            throw new InvalidOperationException("Empty queue.");
        }

        return queue.Dequeue();
    }

    public void Write(T value)
    {
        if (queue.Count >= capacity)
        {
            throw new InvalidOperationException("Full buffer cannot be written to.");
        }
        queue.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (queue.Count >= capacity)
        {
            queue.Dequeue();
        }
        queue.Enqueue(value);
    }

    public void Clear()
    {
        queue = new Queue<T>(capacity);
    }
}