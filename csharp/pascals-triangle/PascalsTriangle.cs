using System;
using System.Collections.Generic;
using System.Linq;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows) => Enumerable.Range(1, rows).Select(Row);

    private static IEnumerable<int> Row (int row)
    {
        yield return 1;
        var value = 1;

        for(var i = 1; i < row; i++)
        {
            value = value * (row - i) / i;
            yield return value;
        }
    }

}