using System;
using System.Collections.Generic;
using System.Linq;

public class Triplet
{
    private int _a;
    private int _b;
    private int _c;

    public Triplet(int a, int b, int c)
    {
        _a = a;
        _b = b;
        _c = c;
    }

    private Triplet(int[] sides) : this(sides[0], sides[1], sides[2]) {}

    public int Sum() => _a + _b + _c;

    public int Product() => _a * _b * _c;

    public bool IsPythagorean() => Math.Pow(_a, 2) + Math.Pow(_b, 2) == Math.Pow(_c, 2);

    public static IEnumerable<Triplet> Where(int maxFactor, int minFactor = 1, int sum = 0)
    {
        return Enumerable.Range(minFactor, maxFactor - minFactor + 1)
            .DifferentCombinations(3)
            .Select(x => new Triplet(x.ToArray()))
            .Where(x => x.IsPythagorean())
            .Where(s => sum > 0 ? s.Sum() == sum : true)
            .OrderBy(x => x.Product());
    }
}

public static class Extensions
{
    public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int num)
    {
        if(num == 0) return new[] { new T[0] };

        return elements.SelectMany((e, i) => elements.Skip(i + 1)
            .DifferentCombinations(num - 1)
            .Select(c => (new[] {e}).Concat(c)));
    }
}