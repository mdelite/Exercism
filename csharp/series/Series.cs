using System;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if( sliceLength > numbers.Length || sliceLength <= 0 || numbers.Length == 0)
            throw new ArgumentException();

        var chunks = new List<string>();
        for(var i = 0; i <= numbers.Length - sliceLength; i++)
        {
            chunks.Add(numbers.Substring(i, sliceLength));
        }
        return chunks.ToArray();
    }
}