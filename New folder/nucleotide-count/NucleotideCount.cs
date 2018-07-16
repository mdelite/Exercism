using System;
using System.Collections.Generic;
using System.Linq;

public class NucleotideCount
{
    private readonly IDictionary<char, int> _counts = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };
    
    private bool IsInvalid(string sequence)
    {
        return sequence.Any(c => !_counts.Keys.Contains(c));
    }
    public NucleotideCount(string sequence)
    {
        if(IsInvalid(sequence)) throw new InvalidNucleotideException();

        foreach( var c in sequence)
        {
            _counts[c]++;           
        }        
    }

    public IDictionary<char, int> NucleotideCounts
    {
        get { return _counts; }
    }
}

public class InvalidNucleotideException : Exception { }
