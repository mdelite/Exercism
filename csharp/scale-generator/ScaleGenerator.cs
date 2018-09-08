using System;
using System.Collections.Generic;
using System.Linq;

public static class ScaleGenerator
{
    private static string[] notes = new[] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"  };
    private static string[] notesFlat = new[] { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };
    private static string[] flatKeys = new[] { "F", "Bb", "Eb", "Ab", "Db", "Gb", "d", "g", "c", "f", "bb", "eb"};
    public static string[] Pitches(string tonic)
    {
        var scale = flatKeys.Contains(tonic) ? notesFlat : notes;
        var startNote = tonic.ToUpperNote();
        return Enumerable.Range(Array.FindIndex(scale, x => x == startNote), 12)
            .Select(i => scale[i % 12])
            .ToArray();
    }

    private static string ToUpperNote(this string note)
    {
        var a = note.ToCharArray();
        a[0] = char.ToUpperInvariant(a[0]);
        return new string(a);
    }

    public static string[] Pitches(string tonic, string pattern)
    {
        var scale =Pitches( tonic);
        var test = GetSteps(pattern)
            .Select(s => scale[s])
            .ToArray();
        return test;
    }

    private static IEnumerable<int> GetSteps( string pattern)
    {
        var i = 0;
        
        foreach(var p in pattern.Take(pattern.Length))
        {
            yield return i;
            switch(p)
            {
                case 'M':
                    i += 2;
                    break;
                case 'm':
                    i += 1;
                    break;
                case 'A':
                    i += 3;
                    break;
                default:
                    throw new ArgumentException($"No case for {nameof(p)}:'{p}' in {nameof(pattern)}:'{pattern}'.");
            }
        }
    }
}