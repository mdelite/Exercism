using System;
using System.Collections.Generic;
using System.Linq;

public static class ScaleGenerator
{
    private static string[] notes = new[] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"  };
    private static string[] notesFlat = new[] { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };
    private static string[] flatKeys = new[] { "F", "Bb", "Eb", "Ab", "Db", "Gb", "d", "g", "c", "f", "bb", "eb"};
    private static Dictionary<char, int> step = new Dictionary<char, int>() {{'m', 1}, {'M', 2}, {'A', 3}};

    public static string[] Pitches(string tonic, string pattern = "mmmmmmmmmmmm")
    {
        var scale = flatKeys.Contains(tonic) ? notesFlat : notes;
        var noteIndex = Array.IndexOf(scale, tonic.First().ToString().ToUpperInvariant() + tonic.Substring(1));

        return pattern.Select(x =>
            {
                var i = noteIndex;
                noteIndex = (noteIndex + Step[x]) % scale.Length;
                return i;
            })
            .Select(x => scale[x])
            .ToArray();
    }
}