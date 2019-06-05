using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Luhn
{
    public static bool IsValid(string number)
    {
        number = Regex.Replace(number,@"\s+", string.Empty);
        if(!Regex.IsMatch(number, @"^\d{2,}$")) return false;

        return number.Select(x => (int)char.GetNumericValue(x))
            .Reverse()
            .Select((x, i) => (i + 1) % 2 == 0 ? Double(x) : x)
            .Sum() % 10 == 0;
    }

    private static int Double(int n) => n * 2 > 9 ? n * 2 - 9 : n * 2;
}