using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var firstLetter = phrase
            .Split( new[] {' ', '-'} )
            .Select(x => Char.ToUpperInvariant(x[0]))
            .ToArray();
            
        return new string(firstLetter);
    }
}