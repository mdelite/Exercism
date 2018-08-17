using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        var test = number.Replace("-","").Replace(" ","");
        var reg = new Regex(@"^\d{9}[\d|X]$");
        var mat = reg.Match(test);

        if(mat.Success)
        {
            return mat.Value.Select(x => x == 'X' ? 10 : int.Parse(x.ToString()))
                .Zip(Enumerable.Range(1, 10).Reverse(), (x, y) => x * y)
                .Sum() % 11 == 0;
        }
        return false;
    }
}