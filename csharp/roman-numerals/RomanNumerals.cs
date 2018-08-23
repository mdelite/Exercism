using System;
using System.Collections.Generic;
using System.Linq;

public static class RomanNumeralExtension
{
    private static Dictionary<int, string> romans = new Dictionary<int, string>()
    {
        { 1000, "M"},
        { 900, "CM"},
        { 500, "D"},
        { 400, "CD"},
        { 100, "C"},
        { 90, "XC"},
        { 50, "L"},
        { 40, "XL"},
        { 10, "X"},
        { 9, "IX"},
        { 5, "V"},
        { 4, "IV"},
        { 1, "I"},
    };

    public static string ToRoman(this int value)
    {
        var roman = "";
        foreach(var r in romans)
        {
            while(value >= r.Key)
            {
                value -= r.Key;
                roman += r.Value;
            }
        }
        return roman;
    }
}