using System;
using System.Collections.Generic;
using System.Linq;

public static class NthPrime
{
    public static int Prime(int nth)
    {
        var primes = new List<int>() { 2 };

        while (primes.Count < nth)
        {
            var c = 1;
            primes.AddRange(Enumerable.Range(primes.Last() + 1, nth));

            var sqrt = Math.Sqrt( primes.Last());
            while (c <= sqrt)
            {
                c = primes.First(x => x > c);
                primes.RemoveAll(x => x != c && x % c == 0);
            }
        }

        return primes[nth - 1];
    }
}