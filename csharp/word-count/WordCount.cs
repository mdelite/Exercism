using System;
using System.Collections.Generic;
using System.Linq;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        var words = phrase
            .ScrubPhrase()
            .Split(new[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries)
            .Select(ScrubWord);

        return words.Distinct().ToDictionary(x => x, x => words.Count(y => y == x));
    }

    public static string ScrubPhrase(this string s) => new string(s
            .Where(c => char.IsLetterOrDigit(c) || c == ',' || c == ' ' || c == '\'')
            .Select(char.ToLowerInvariant)
            .ToArray());

    public static string ScrubWord(string word)
    {
        return word.StartsWith('\'') && word.EndsWith('\'') ? word.Substring(1, word.Length - 2) : word;
    }
}