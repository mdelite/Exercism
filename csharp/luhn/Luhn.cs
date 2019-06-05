using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Luhn
{
    public static bool IsValid(string number)
    {
        var digits = number.Replace(" ", string.Empty);
        var rx = new Regex(@"^\d{2,}$");
        if(!rx.IsMatch(digits)) return false;

        return digits.Select(x => (int)char.GetNumericValue(x)).Reverse()
            .Select((x, i) => (i + 1) % 2 == 0 ? Double(x) : x)
            .Sum() % 10 == 0;
    }

    private static int Double(int n)
    {
         return n * 2 > 9 ? n * 2 - 9 : n* 2;
    }

     
}