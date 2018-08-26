using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    private int _value;
    private BinarySearchTree _left;
    private BinarySearchTree _right;

    public BinarySearchTree(int value)
    {
        this._value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        _value = values.FirstOrDefault();
        var leftValues = values.Skip(1).Where(i => i <= _value);
        var rightValues = values.Skip(1).Where(i => i > _value);
        
        if(leftValues.Count() > 0) _left = new BinarySearchTree(leftValues);
        if(rightValues.Count() > 0) _right = new BinarySearchTree(rightValues);
    }
 
    public int Value
    {
        get
        {
            return _value;
        }
    }

    public BinarySearchTree Left
    {
        get
        {
            return _left;
        } 
    }

    public BinarySearchTree Right
    {
        get
        {
            return _right;
        }
    }

    public BinarySearchTree Add(int value)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<int> GetEnumerator()
    {
        var collection = (new int[]{})
            .Concat(_left != null ? _left.AsEnumerable() : new int[]{})
            .Concat(new[] { _value})
            .Concat(_right != null ? _right.AsEnumerable() : new int[]{});

        foreach(var item in collection)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}