using System;
using System.Linq;
using System.Collections.Generic;

public static class Sieve
{
    public static int[] Primes(int limit) => Eratosthenes(limit).ToArray();

    private static IEnumerable<int> Eratosthenes(int limit)
    {
        if(limit < 2) throw new ArgumentOutOfRangeException($"Limit:'{limit}' must be 2 or greater.");

        var primeCandidates =  Enumerable.Range(2,limit - 1);
        while(primeCandidates.Any())
        {
            var prime = primeCandidates.First();
            primeCandidates = primeCandidates.Where(x => x % prime != 0);
            yield return prime;
        }
    }
}