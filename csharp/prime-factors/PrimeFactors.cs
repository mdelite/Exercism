using System;
using System.Collections.Generic;
using System.Linq;

public static class PrimeFactors
{
    public static int[] Factors(long number) => GetFactors(number).ToArray();

    private static IEnumerable<int> GetFactors(long number)
    {
        var n = number;   
        for(var i = 2; i <= n; i++ )
        {
            while(n % i == 0)
            {
                n /= i;
                yield return i;
            }
        }
    }
}