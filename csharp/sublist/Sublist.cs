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
        if(list1.Count < list2.Count)
            return list2.Contains(list1) ? SublistType.Sublist : SublistType.Unequal;

        if(list1.Count > list2.Count)
            return list1.Contains(list2) ? SublistType.Superlist : SublistType.Unequal;

        return list1.SequenceEqual(list2) ? SublistType.Equal : SublistType.Unequal;
    }

    private static bool Contains<T>(this List<T> list2, List<T> list1 ) => 
        Enumerable.Range(0, list2.Count - list1.Count + 1)
            .Any(i => list2.GetRange(i,list1.Count).SequenceEqual(list1));
}