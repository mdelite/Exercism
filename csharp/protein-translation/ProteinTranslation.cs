using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    private static Dictionary<string, string> codons = new Dictionary<string, string>
    {
        {"AUG", "Methionine"},
        {"UUU", "Phenylalanine"},
        {"UUC", "Phenylalanine"},
        {"UUA", "Leucine"},
        {"UUG", "Leucine"},
        {"UCU", "Serine"},
        {"UCC", "Serine"},
        {"UCA", "Serine"},
        {"UCG", "Serine"},
        {"UAU", "Tyrosine"},
        {"UAC", "Tyrosine"},
        {"UGU", "Cysteine"},
        {"UGC", "Cysteine"},
        {"UGG", "Tryptophan"},
        {"UAA", string.Empty},
        {"UAG", string.Empty},
        {"UGA", string.Empty}
    };
    public static string[] Proteins(string strand) => strand
        .Split(3)
        .Select(x => codons[x])
        .TakeWhile(x => x != string.Empty)
        .ToArray();

    private static IEnumerable<string> Split(this string s, int size) => Enumerable
        .Range(0, s.Length / size)
        .Select(x => s.Substring(x * size, size));
}