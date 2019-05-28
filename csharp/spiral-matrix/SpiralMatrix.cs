using System;
using System.Collections.Generic;
using System.Linq;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var rows = GetMatrixRows(size).ToList();

        var matrix = new int[size, size];
        for (var r = 0; r < size; r++)
        {
            for (var c = 0; c < size; c++)
            {
                matrix[r, c] = rows[r][c];
            }
        }

        return matrix;
    }

    private static IEnumerable<List<int>> GetMatrixRows(int size)
    {
        var middleMatrix = size > 2 ? GetMatrixRows(size - 2).ToList() : null;

        var offset = (size - 1) * 4; //Offset to apply to middle matrix

        for (int r = 0; r < size; r++)
        {
            if (r == 0) //top row
            {
                yield return Enumerable.Range(1, size).ToList();
            }
            else if (r == size - 1) //bottom row
            {
                yield return Enumerable.Range(size * 2 - 1, size).Reverse().ToList();
            }
            else  //middle rows
            {
                var row = new List<int>();

                row.Add(offset + 1 - r); //first column
                row.AddRange(
                    Enumerable.Range(0, middleMatrix[0].Count)
                    .Select(x => middleMatrix[r - 1][x] + offset)
                );
                row.Add(size + r); //last column

                yield return row;
            }
        }
    }
}