using System;
using System.Linq;
using System.Collections.Generic;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if(limit < 2) throw new ArgumentOutOfRangeException($"Limit:'{limit}' must be 2 or greater.");

        var primes = new List<int>();
        var sieve =  Enumerable.Repeat(true, limit + 1).ToArray();
        sieve[0] = false;
        sieve[1] = false;

        for(var i = 2; i < sieve.Length; i++)
        {
            if(sieve[i])
            {
                primes.Add(i);

                var mult = i + i;
                while(mult < sieve.Length)
                {
                    sieve[mult] = false;
                    mult += i;
                }
            }
        }
 
        return primes.ToArray();
    }

}