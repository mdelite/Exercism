using System;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        var sum = 0;
        for(var x = 1; x <= max; x++)
        {
            sum += x;
        }

        return (int)Math.Pow(sum, 2);
    }

    public static int CalculateSumOfSquares(int max)
    {
        var sum = 0;
        for(var x = 1; x <= max; x++)
        {
            sum += (int)Math.Pow(x, 2);
        }

        return sum;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}