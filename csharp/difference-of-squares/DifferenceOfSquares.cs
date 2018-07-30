using System;
using System.Collections.Generic;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max) => max
        .NaturalNumbers()
        .Sum()
        .Square();


    public static int CalculateSumOfSquares(int max) => max
        .NaturalNumbers()
        .Select(Square)
        .Sum();

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }

    private static IEnumerable<int> NaturalNumbers(this int max) => Enumerable.Range(1, max);

    private static int Square(this int num) => num * num;
}