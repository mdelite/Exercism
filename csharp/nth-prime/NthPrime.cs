using System;
using System.Collections.Generic;
using System.Linq;

public static class NthPrime
{
    public static int Prime(int nth) => Primes().ElementAt(nth - 1);

    private static IEnumerable<int> Primes()
    {
        yield return 2;
        yield return 3;

        var i = 6;
        while (true)
        {
            if (IsPrime(i - 1)) yield return i - 1;
            if (IsPrime(i + 1)) yield return i + 1;
            i += 6;
        }
    }

    private static bool IsPrime(int n)
    {
        var r = (int)Math.Floor(Math.Sqrt(n));
        return r < 5 || Enumerable.Range(5, r - 4).All(x => n % x != 0);
    }
}