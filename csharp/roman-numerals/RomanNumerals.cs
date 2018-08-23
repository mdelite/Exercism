using System;
using System.Collections.Generic;
using System.Linq;

public static class RomanNumeralExtension
{
    private enum Romans
    {
        I = 1,
        IV = 4,
        V = 5,
        IX = 9,
        X = 10,
        XL = 40,
        L = 50,
        XC = 90,
        C = 100,
        CD = 400,
        D = 500,
        CM = 900,
        M = 1000        
    }
    public static string ToRoman(this int value)
    {
        var roman = "";
        while(value > 0)
        {
            var max = Enum.GetValues(typeof(Romans)).Cast<int>().TakeWhile(x => x <= value).Max();
            roman += ((Romans)max).ToString();
            value -= max;
        }
        return roman;
    }
}