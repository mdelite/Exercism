using System;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if(span < 0 || span > digits.Length || digits.Where(x => !char.IsNumber(x)).Count() > 0) throw new ArgumentException();

        var max = 0;
        for(var i = 0; i <= digits.Length - span; i++)
        {
            var chunk = digits.Substring(i, span);
            int chunkProd = GetLargestProduct(chunk);

            if(chunkProd > max) max = chunkProd;
        }
        return max;
    }

    private static int GetLargestProduct(string chunk)
    {
        var prod = 1;
        chunk.ToList().ForEach(x => prod *= int.Parse(x.ToString()));
        return prod;
    }
}