using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        var sum = 0;

        for(var i = 1; i < max; i++)
        {
            if(multiples.FirstOrDefault(x => i % x == 0) > 0) sum += i;
        }

        return sum;
    }
}