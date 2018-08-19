using System;
using System.Collections.Generic;

public static class ListOps
{
    public static int Length<T>(List<T> input) => 
        Foldl(input, 0, (count, item) => count + 1);

    public static List<T> Reverse<T>(List<T> input) => Foldl(input, new List<T>(), (list, item) => 
        Append(new List<T>() { item }, list));

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map) => 
        Foldl(input, new List<TOut>(), (list, item) => Append(list, new List<TOut>() { map(item) }));

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate) => 
        Foldl(input, new List<T>(), (list, item) => Append(list, predicate(item) ? new List<T>() { item } : new List<T>()));

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        var output = start;
        foreach (var item in input)
        {
            output = func(output, item);
        }
        return output;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func) => 
        Foldl(Reverse(input), start, (y, x) => func(x, y));

    public static List<T> Concat<T>(List<List<T>> input) => 
        Foldl(input, new List<T>(), (list, item) => Append(list, item));

    public static List<T> Append<T>(List<T> left, List<T> right) => 
        Foldl(right, new List<T>(left), (list, item) => { list.Add(item); return list; });
}