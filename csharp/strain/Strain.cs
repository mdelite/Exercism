using System;
using System.Collections.Generic;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var keepers = new List<T>();

        foreach(var c in collection)
        {
            if(predicate(c)) keepers.Add(c);
        }

        return keepers;
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var keepers = new List<T>();

        foreach(var c in collection)
        {
            if(!predicate(c)) keepers.Add(c);
        }

        return keepers;
    }
}