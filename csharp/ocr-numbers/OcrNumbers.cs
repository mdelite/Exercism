using System;
using System.Linq;
using System.Collections.Generic;

public static class OcrNumbers
{
    public static string Convert(string input)
    {
        var lines = input.Split("\n");
        if( lines.Count() < 4 || lines[0].Length % 3 != 0) throw new ArgumentException();

        var digits = Enumerable.Range(0, lines[0].Length / 3)
            .Select(y => Enumerable.Range(0, 4)
                .Select( x => lines[x].Substring(y * 3, 3) ))
            .Select(x => GetChar(x));

        return string.Join("", digits);
    }

    private static char GetChar(IEnumerable<string> text)
    {
        var s = string.Join("", text).TrimEnd();
        switch( s )
        {
            case " _ | ||_|":
                return '0';
            case "     |  |":
                return '1';
            default:
                return '?';
        }
    }
}