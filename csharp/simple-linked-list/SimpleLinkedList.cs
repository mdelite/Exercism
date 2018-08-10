using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    public SimpleLinkedList(T value)
    {
        this.Value = value;
    }

    public SimpleLinkedList(IEnumerable<T> values) : this(values.First())
    {
        var current = this;
        foreach(var value in values.Skip(1))
        {
            current.Next = new SimpleLinkedList<T>(value);
            current = current.Next;
        }
    }

    public T Value {get;}
    
    public SimpleLinkedList<T> Next {get; private set;}

    public SimpleLinkedList<T> Add(T value)
    {
        var current = this;
        current.Next = new SimpleLinkedList<T>(value);
        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = this;
        while(node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();
}