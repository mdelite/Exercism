using System;
using System.Text.RegularExpressions;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        var regex = new Regex(@"(.)\1*");
        var output = "";

        foreach (Match match in regex.Matches(input))
        {
            if(match.Value.Length > 1)
            {
                output += match.Value.Length.ToString();
            }

            output += match.Value.Substring(0,1);
        }

        return output;
    }

    public static string Decode(string input)
    {
        var regex = new Regex(@"(\d*)(.)");
        var output = "";

        foreach (Match match in regex.Matches(input))
        {
            var c = 0;
            if ( !int.TryParse(match.Groups[1].Value, out c)) c = 1;

            output += new string(Char.Parse( match.Groups[2].Value),c);
        }

        return output;
    }
}
