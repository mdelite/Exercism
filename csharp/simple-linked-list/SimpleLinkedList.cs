using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private List<T> _linkedList;
    public SimpleLinkedList(T value)
    {
        _linkedList = new List<T>();
        _linkedList.Add(value);
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        _linkedList = new List<T>();
        values.ToList().ForEach(x => _linkedList.Add(x));
    }

    public T Value 
    { 
        get
        {
            return _linkedList[0];
        } 
    }

    public SimpleLinkedList<T> Next
    { 
        get
        {
            if(_linkedList.Count() > 1)
            {
                return new SimpleLinkedList<T> (_linkedList.Skip(1));
            }
            return null;
        } 
    }

    public SimpleLinkedList<T> Add(T value)
    {
        _linkedList.Add(value);
        return this;
    }

    public IEnumerator<T> GetEnumerator() => _linkedList.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();
}