using System;
using System.Text.RegularExpressions;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        var pattern = @"(.)\1{0,}";
        var regex = new Regex(pattern);
        var output = "";
        foreach (Match match in regex.Matches(input))
        {
            var len = match.Value.Length;
            if(len > 1)
            {
                output += len.ToString();
            }

            output += match.Value.Substring(0,1);
        }
        return output;
    }

    public static string Decode(string input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
