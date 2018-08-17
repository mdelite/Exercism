using System;
using System.Linq;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if(inputBase <= 1) throw new ArgumentException($"Invalid {nameof(inputBase)}:{inputBase}");
        if(outputBase <= 1) throw new ArgumentException($"Invalid {nameof(outputBase)}:{outputBase}");
        if(inputDigits.Any(x => x < 0 || x >= inputBase)) throw new ArgumentException($"Invalid digit in {nameof(inputDigits)}");

        var value = inputDigits
            .Reverse()
            .Select((x, i) => x * Math.Pow(inputBase, i))
            .Sum();
        
        if(value == 0) return new[] { 0 };
        
        return Enumerable.Range(0, (int)Math.Floor(Math.Log(value, outputBase) + 1))
            .Reverse()
            .Select(GetOutputDigit)
            .ToArray();

        int GetOutputDigit(int position)
        {
            var digitVal = Math.Pow(outputBase, position);
            var n = (int)Math.Floor(value / digitVal);
            value -= n * digitVal;
            return n;
        }
    }
}