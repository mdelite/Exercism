using System;
using System.Linq;

public class Anagram
{
    private string _base;

    public Anagram(string baseWord) => _base = baseWord.ToLowerInvariant();

    public string[] Anagrams(string[] potentialMatches) => potentialMatches
            .Where(x => new string(_base.OrderBy(c => c).ToArray()) == new string(x.ToLowerInvariant().OrderBy(c => c).ToArray()) && _base != x.ToLowerInvariant())
            .ToArray();
}