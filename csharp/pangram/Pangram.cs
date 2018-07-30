using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input) => input.ToLowerInvariant()
            .Where(IsLetter)
            .Distinct()
            .Count() == 26;

    public static bool IsLetter(this char c) => (int)c >= 97 && (int)c <= 122;
}
