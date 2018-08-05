using System;
using System.Linq;
using System.Collections.Generic;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if(limit < 2) throw new ArgumentOutOfRangeException($"Limit:'{limit}' must be 2 or greater.");

        var sieve =  Enumerable.Range(0,limit + 1).ToArray();

        for(var i = 2; i < sieve.Length; i++)
        {
            if(sieve[i] > 0)
            {
                var mult = i + i;
                while(mult < sieve.Length)
                {
                    sieve[mult] = 0;
                    mult += i;
                }
            }
        }
 
        return sieve.Where(p => p >= 2).ToArray();
    }
}