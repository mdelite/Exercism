using System;
using System.Linq;
using System.Collections.Generic;

public static class OcrNumbers
{
    public static string Convert(string input)
    {
        var rows = input.Split("\n");
        if (rows.Count() % 4 != 0) throw new ArgumentException();

        var numbers = rows.Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / 4)
            .Select(x => x.Select(y => y.Value))
            .Select(x => Convert(x.ToArray()));

        return string.Join(',', numbers);
    }

    private static string Convert(string[] input)
    {
        if (input[0].Length % 3 != 0) throw new ArgumentException();

        var digits = Enumerable.Range(0, input[0].Length / 3)
            .Select(y => Enumerable.Range(0, 4)
                            .Select(x => input[x].Substring(y * 3, 3)))
            .Select(x => GetDigits(String.Join("", x)));

        return string.Join("", digits);
    }

    private static char GetDigits(string input)
    {
        string[] digits = { " _ | ||_|   ", "     |  |   ", " _  _||_    ", " _  _| _|   ", "   |_|  |   ",
            " _ |_  _|   ", " _ |_ |_|   ", " _   |  |   ", " _ |_||_|   ", " _ |_| _|   "};
        
        var d = Array.IndexOf(digits, input);
        if( d < 0 ) return '?';
        return (char)('0' + d);
    }
}