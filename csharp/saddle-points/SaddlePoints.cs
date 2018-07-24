using System;
using System.Collections.Generic;
using System.Linq;

public class SaddlePoints
{
    private int[,] _matrix;
    public SaddlePoints(int[,] values) => _matrix = values;

    public IEnumerable<(int, int)> Calculate()
    {
        var saddles = new List<(int, int)>();

        //array to hold col min values so we only look once.
        var colMin = new int?[_matrix.GetLength(1)];

        //iterate through each row and find max value
        for(var r = 0; r < _matrix.GetLength(0); r++)
        {
            var rowMax = GetRowValues(r).Max();

            //check each val in row. add to list if it is equal to rows max and cols min.
            for(var c = 0; c < _matrix.GetLength(1); c++)
            {
                if(colMin[c] == null) colMin[c] = GetColumnValues(c).Min();

                var val = _matrix[r, c];

                if(val == rowMax && val == colMin[c]) saddles.Add((r, c));
            }
        }
        return saddles;
    }

    private int[] GetRowValues(int index)
    {
        return Enumerable.Range(0, _matrix.GetUpperBound(1) + 1)
            .Select(i => _matrix[index, i])
            .ToArray();
    }

    private int[] GetColumnValues(int index)
    {
        return Enumerable.Range(0, _matrix.GetUpperBound(0) + 1)
            .Select(i => _matrix[i, index])
            .ToArray();
    }
}