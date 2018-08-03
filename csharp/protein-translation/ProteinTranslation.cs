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
    public static string[] Proteins(string strand) => Split(strand).Select(x => codons[x]).ToArray();

    private static string[] Split(string strand)
    {
        var strands = new List<string>();

        for(var i = 0; i <= strand.Length - 3; i += 3)
        {
            var codon = strand.Substring(i, 3);
            if(codons[codon] == string.Empty) return strands.ToArray();

            strands.Add(codon);
        }

        return strands.ToArray();
    }
}