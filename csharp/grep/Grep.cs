using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        var regex = new Regex(flags.Contains("-x") ? $"^{pattern}$" : pattern, flags.Contains("-i") ? RegexOptions.IgnoreCase : RegexOptions.None);

        return string.Join("\n", files.Select(FindMatches).Where(x => !string.IsNullOrEmpty(x)));

        string FindMatches(string file)
        {
            if(flags.Contains("-l")) return IsMatch(File.ReadAllText(file)) ? file : "";

            var fileTag = files.Length > 1 ? $"{file}:" : "";
            return string.Join("\n", File.ReadAllLines(file)
                .Select((text, i) => IsMatch(text) ? $"{fileTag}{(flags.Contains("-n") ? $"{i + 1}:" : "")}{text}" : "")
                .Where(x => !string.IsNullOrEmpty(x)));
        }

        bool IsMatch(string text)
        {   
            var isMatch = regex.IsMatch(text);
            return flags.Contains("-v") ? !isMatch : isMatch;
        }
    }
}