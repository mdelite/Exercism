using System;
using System.Collections.Generic;
using System.Linq;

public class Matrix
{
    private List<int[]> _rows;
    public Matrix(string input)
    {
        _rows = input
            .Split('\n')
            .Select(x => x.Split(' ')
                .Select(int.Parse)
                .ToArray())
            .ToList();
    }

    public int Rows
    {
        get
        {
            return _rows.Count();
        }
    }

    public int Cols
    {
        get
        {
            return _rows[0].Count();
        }
    }

    public int[] Row(int row) => _rows[row];

    public int[] Column(int col) => _rows.Select(x => x[col]).ToArray();
}