using System;
using System.Collections.Generic;
using System.Linq;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        if(rows < 0) throw new ArgumentOutOfRangeException($"'{nameof(rows)}' must be greater or equal to 0.");
        
        List<int[]> triangle = new List<int[]>();

        for(var i = 0; i < rows; i++)
        {
            if(i == 0)
            {
                triangle.Add(new[] { 1 });
            } 
            else
            {
                var row = Enumerable.Range(0, i + 1)
                    .Select(x => GetVal(x, triangle[i - 1]))
                    .ToArray();
                triangle.Add(row);
            }
        }
        return triangle;
    }

    private static int GetVal(int position, int[] previousRow)
    {
        var left = position == 0 ? 0 : previousRow[position - 1];
        var right = position == previousRow.Length ? 0 : previousRow[position];

        return left + right;
    }

}