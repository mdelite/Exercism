using System;
using System.Text.RegularExpressions;
using System.Linq;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        var regex = new Regex(@"(.)\1*");

        return regex.Replace(input, m => (m.Value.Length > 1 ? m.Value.Length.ToString() : "") + m.Value[0].ToString());
    }

    public static string Decode(string input)
    {
        var regex = new Regex(@"(\d*)(.)");

        return regex.Replace(input, m => new string(m.Groups[2].Value[0], m.Groups[1].Value == "" ? 1 : int.Parse(m.Groups[1].Value)));
    }
}
