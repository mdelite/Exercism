using System;
using System.Collections.Generic;
using System.Linq;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var matrix = new int[size, size];

        var rows = new List<List<int>>();

        int[,] middleMatrix = new int[,] { };
        if (size >= 3) middleMatrix = GetMatrix(size - 2);

        var offset = (size - 1) * 4; //Offset to apply to middle matrix

        for (int r = 0; r < size; r++)
        {
            if (r == 0) //top row
            {
                rows.Add(Enumerable.Range(1, size).ToList());
            }
            else if (r == size - 1) //bottom row
            {
                rows.Add(Enumerable.Range(size * 2 - 1, size).Reverse().ToList());
            }
            else  //middle rows
            {
                var row = new List<int>();
                row.Add(offset + 1 - r); //first column

                row.AddRange(
                    Enumerable.Range(0,middleMatrix.GetLength(1))
                    .Select(x => middleMatrix[r - 1, x] + offset)
                );

                row.Add(size + r); //last column

                rows.Add(row);
            }
        }

        //fill the matrix
        

        for (var r = 0; r < size; r++)
        {
            for (var c = 0; c < size; c++)
            {
                matrix[r, c] = rows[r][c];
            }
        }

        return matrix;
    }
}