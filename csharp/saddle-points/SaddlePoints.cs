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

        var colMin = new int?[_matrix.GetLength(1)];   
        for(var r = 0; r < _matrix.GetLength(0); r++)
        {
            var row = Enumerable.Range(0, _matrix.GetUpperBound(1) + 1)
                      .Select(i => _matrix[r, i])
                      .ToArray();

            var rowMax = row.Max();

            for(var c = 0; c < _matrix.GetLength(1); c++)
            {
                if(colMin[c] == null) colMin[c] = GetColumnMin(c);

                var val = _matrix[r, c];

                if(val == rowMax && val == colMin[c]) saddles.Add((r, c));
            }
        }
        
        return saddles;
    }

    private int GetColumnMin(int columnIndex)
    {
        var col = Enumerable.Range(0, _matrix.GetUpperBound(0) + 1)
            .Select(i => _matrix[i, columnIndex])
            .ToArray();
        
        return col.Min();
    }
}