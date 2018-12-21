using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomSet : IEnumerable<int>
{
    private IEnumerable<int> _values;

    public CustomSet()
    {
        _values = Enumerable.Empty<int>();
    }
    
    public CustomSet(params int[] values)
    {
        _values = values.Distinct().OrderBy(x => x);
    }

    public CustomSet Add(int value)
    {
        if (!_values.Contains(value))
        {
            _values = _values.Append(value).OrderBy(x => x);
        }
        return this;
    }

    public bool Empty() => _values.Count() == 0;

    public bool Contains(int value) => _values.Contains(value);

    public bool Subset(CustomSet right)
    {
        foreach(var val in _values)
        {
            if(!right.Contains(val))
            {
                return false;
            }
        }
        return true;
    }

    public bool Disjoint(CustomSet right)
    {
        foreach(var val in _values)
        {
            if(right.Contains(val))
            {
                return false;
            }
        }
        return true;
    }

    public CustomSet Intersection(CustomSet right) => new CustomSet(_values.Intersect(right).ToArray());

    public CustomSet Difference(CustomSet right) => new CustomSet(_values.Where(x => !this.Intersection(right).Contains(x)).ToArray());

    public CustomSet Union(CustomSet right)
    {
        right.ToList().ForEach(x => this.Add(x));
        return this;
    }

    public int Count => _values.Count();

    public override bool Equals(object obj)
    {
        if(obj == null || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }

        var right = (CustomSet)obj;

        if(this.Count != right.Count)
        {
            return false;
        }

        foreach(var d in this)
        {
            if(!right.Contains(d))
            {
                return false;
            }
        }

        return true;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return _values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _values.GetEnumerator();
    }
}