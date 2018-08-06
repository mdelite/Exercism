using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word) => word.Where(char.IsLetter).Select(char.ToLowerInvariant).Distinct().Count() == word.Where(char.IsLetter).Count();
}
