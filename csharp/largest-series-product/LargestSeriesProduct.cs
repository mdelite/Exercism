using System;
using System.Linq;
using System.Collections.Generic;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if(span < 0) throw new ArgumentException($"'{nameof(span)}' must be greater than 0");
        if(span > digits.Length) throw new ArgumentException($"'{nameof(span)}' must be less than or equal to the number of digits.");
        if(!digits.All(char.IsNumber)) throw new ArgumentException($"'{nameof(digits)}' can only contain numbers");

        return Products(digits, span).Max();
    }

    private static IEnumerable<int> Products(string digits, int span)
    {
        for(var i = 0; i <= digits.Length - span; i++)
        {
            yield return digits.Substring(i, span)
                .Select(x => (int)char.GetNumericValue(x))
                .Aggregate(1, (a, b) => a * b);
        }
    }
}