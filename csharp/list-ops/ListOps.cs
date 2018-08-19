using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input) => 
        Foldl(input, 0, (c, item) => c + 1);

    public static List<T> Reverse<T>(List<T> input) => 
        Foldl(input, new List<T>(), (list, item) => Append(new List<T> { item }, list));

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map) => 
        Foldl(input, new List<TOut>(), (list, item) => Append(list, new List<TOut> { map(item) }));

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate) => 
        Foldl(input, new List<T>(), (list, item) => Append(list, predicate(item) ? new List<T> { item } : new List<T>()));

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        foreach (var item in input)
        {
            start = func(start, item);
        }
        return start;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func) => 
        Foldl(Reverse(input), start, (s, item) => func(item, s));

    public static List<T> Concat<T>(List<List<T>> input) => 
        Foldl(input, new List<T>(), (list, item) => Append(list, item));

    public static List<T> Append<T>(List<T> left, List<T> right) => 
        Foldl(right, left, (list, item) => { list.Add(item); return list; });
}