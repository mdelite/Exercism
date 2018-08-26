using System;
using System.Collections.Generic;
using System.Linq;

public static class Minesweeper
{
    private static readonly char mine = '*';
    public static string[] Annotate(string[] input)
    {
        var minefield = new List<string>();
        for(var row = 0; row < input.Length; row++)
        {
            var minefieldRow = "";
            for(var col = 0; col < input[row].Length; col++)
            {
                minefieldRow += input[row][col] == mine ? mine : MineCount(row, col, ref input);
            }
            minefield.Add(minefieldRow);
        }
        return minefield.ToArray();
    }

    private static char MineCount(int row, int col, ref string[] input)
    {
        var startRow = row == 0 ? 0 : row - 1;
        var startCol = col == 0 ? 0 : col - 1;
        var endRow = row + 1 < input.Length ? row + 1 : row;
        var endCol = col + 1 < input[row].Length ? col + 1 : col;

        var count = 0;
        for(var r = startRow; r <= endRow; r++)
        {
            for(var c = startCol; c <= endCol; c++)
            {
                if(input[r][c] == mine) count++;
            }
        }
        return count == 0 ? ' ' : char.Parse(count.ToString());
    }
}
