using System;
using System.Collections.Generic;
using System.Linq;

public static class PrimeFactors
{
    public static int[] Factors(long number) => GetFactors(number).ToArray();

    private static IEnumerable<int> GetFactors(long number)
    {
        for(var i = 2; i <= number; i++ )
        {
            while(number % i == 0)
            {
                number /= i;
                yield return i;
            }
        }
    }
}