using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value) => Value = value;

    public BinarySearchTree(IEnumerable<int> values)
    {
        Value = values.FirstOrDefault();

        foreach(var v in values.Skip(1))
        {
            Add(v);
        }
    }
 
    public int Value { get; }
    public BinarySearchTree Left { get; private set; }
    public BinarySearchTree Right { get; private set; }

    public BinarySearchTree Add(int value)
    {
        if(value <= Value)
        {
            Left = Left?.Add(value) ?? new BinarySearchTree(value);
        }
        else
        {
            Right = Right?.Add(value) ?? new BinarySearchTree(value);
        }
        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        foreach(var value in Left?.AsEnumerable() ?? Enumerable.Empty<int>()) yield return value;

        yield return Value;

        foreach(var value in Right?.AsEnumerable() ?? Enumerable.Empty<int>()) yield return value;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}