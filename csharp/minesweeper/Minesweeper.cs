using System;
using System.Collections.Generic;
using System.Linq;

public static class Minesweeper
{
    private static readonly char mine = '*';
    public static string[] Annotate(string[] input)
    {
        return Enumerable.Range(0, input.Length)
            .Select(x => string.Concat(Enumerable.Range(0, input[x].Length).Select(y => MineFinder(x, y))))
            .ToArray();

        char MineFinder(int r, int c)
        {
            if(input[r][c] == mine) return mine;

            var rowStart = r > 0 ? r - 1 : r;
            var rowEnd = r + 1 < input.Length ? r + 1 : r;
            var colStart = c > 0 ? c - 1 : c;
            var colEnd = c + 1 < input[r].Length ? c + 1 : c;

            var count = Enumerable.Range(rowStart, rowEnd - rowStart + 1)
                .Select(x => Enumerable.Range(colStart, colEnd - colStart + 1).Count(y => input[x][y] == mine))
                .Sum();
            
            return count == 0 ? ' ' : (char)(count + '0');
        }
    }
}
