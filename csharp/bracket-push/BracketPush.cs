using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
public static class BracketPush
{
    public static bool IsPaired(string input)
    {
        var brackets = new Dictionary<char, char>() {{'[', ']'}, {'{', '}'}, {'(', ')'}};

        var test = input.FirstOrDefault(c => brackets.Keys.Contains(c) || brackets.Values.Contains(c));

        if(test != '\0')
        {
            if(brackets.Values.Contains(test)) return false;

            var pattern = $"[{test}](.*)[{brackets[test]}]";
            var match = Regex.Match(input, pattern);

            return match.Success && IsPaired(match.Groups[1].Value);
        }

        return true;
    }
}
