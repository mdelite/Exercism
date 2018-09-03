using System;
using System.Collections.Generic;
using System.Linq;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        if(list1.Count == list2.Count)
            return list1.IsEqual(list2) ? SublistType.Equal : SublistType.Unequal;

        if(list1.Count > list2.Count)
            return IsSublist(list2, list1) ? SublistType.Superlist : SublistType.Unequal;

        return IsSublist(list1, list2) ? SublistType.Sublist : SublistType.Unequal;
    }

    private static bool IsSublist<T>(List<T> list1, List<T> list2) where T : IComparable
    {
        if (list1.Count == 0) return true;

        return Enumerable.Range(0, list2.Count - list1.Count + 1)
                    .Select(i => list2.Skip(i).Take(list1.Count).IsEqual(list1))
                    .Count(x => x) > 0;
    }

    private static bool IsEqual<T> (this IEnumerable<T> list1, IEnumerable<T> list2 )
    {
        if(list1.Count() != list2.Count()) return false;
        if(list1.Count() == 0) return true;

        return list1.Zip(list2, (a, b) => a.Equals(b))
            .Aggregate((a, b) => a && b);
    }
}