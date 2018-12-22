using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomSet : IEnumerable<int>
{
    private SortedSet<int> _values;

    public CustomSet() => _values = new SortedSet<int>();

    public CustomSet(params int[] values) => _values = new SortedSet<int>(values);

    public CustomSet Add(int value)
    {
        _values.Add(value);
        return this;
    }

    public bool Empty() => _values.Count() == 0;

    public bool Contains(int value) => _values.Contains(value);

    public bool Subset(CustomSet right) => _values.IsSubsetOf(right);

    public bool Disjoint(CustomSet right) => !_values.Any(x => right.Contains(x));

    public CustomSet Intersection(CustomSet right) => new CustomSet(_values.Intersect(right).ToArray());

    public CustomSet Difference(CustomSet right) => new CustomSet(_values.Where(x => !this.Intersection(right).Contains(x)).ToArray());

    public CustomSet Union(CustomSet right)
    {
        _values.UnionWith(right);
        return this;
    }

    public int Count => _values.Count();

    public override bool Equals(object obj)
    {
        if(obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        var right = (CustomSet)obj;

        if(this.Count != right.Count)
        {
            return false;
        }

        return _values.All(x => right.Contains(x));
    }

    public override int GetHashCode() => _values.GetHashCode();

    public IEnumerator<int> GetEnumerator() => _values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();
}