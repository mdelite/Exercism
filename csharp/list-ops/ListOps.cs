using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        var c = 0;
        foreach(var item in input)
        {
            c++;
        }
        return c;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        var output = new List<T>();
        var start = Length(input) - 1;
        for (int i = start; i >= 0; i--)
        {
            output.Add(input[i]);
        }
        return output;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        var output = new List<TOut>();
        foreach(var item in input)
        {
            output.Add(map(item));
        }
        return output;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        var output = new List<T>();
        foreach (var item in input)
        {
            if(predicate(item))
            {
                output.Add(item);
            }
        }
        return output;
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        var output = start;
        foreach (var item in input)
        {
            output = func(output, item);
        }
        return output;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        var output = start;
        var inputReversed = Reverse(input);
        foreach (var item in inputReversed)
        {
            output = func(item, output);
        }
        return output;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        var output = new List<T>();
        foreach(var item in input)
        {
            output = Append(output, item);
        }
        return output;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        var output = left;
        foreach(var item in right)
        {
            output.Add(item);
        }
        return output;
    }
}