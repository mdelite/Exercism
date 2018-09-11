using System;
using System.Collections;
using System.Collections.Generic;

public class Deque<T>
{
    private List<T> _collection;

    public Deque() => _collection = new List<T>();
    public void Push(T value) => _collection.Add(value);

    public T Pop()
    {
        var p = _collection[_collection.Count - 1];
        _collection.RemoveAt(_collection.Count - 1);
        return p;
    }

    public void Unshift(T value) => _collection.Insert(0, value);

    public T Shift()
    {
        var p = _collection[0];
        _collection.RemoveAt(0);
        return p;
    }
}