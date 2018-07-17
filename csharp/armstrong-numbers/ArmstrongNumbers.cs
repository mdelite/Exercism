using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var sum = 0;
        foreach(var digit in number.ToString())
        {
            sum += (int)Math.Pow((int)char.GetNumericValue(digit),Math.Floor(Math.Log10(number) + 1));
        }

        return sum == number;
    }
}