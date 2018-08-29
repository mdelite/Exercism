using System;
using System.Collections.Generic;
using System.Linq;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        return texts.Aggregate("", (x, y) => x + y)
            .ToLowerInvariant()
            .Where(x => char.IsLetter(x))
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());  
    }
}