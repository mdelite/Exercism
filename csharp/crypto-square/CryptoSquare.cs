using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext) => Regex.Replace(plaintext.ToLowerInvariant(), "\\W", "");

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        var normalizedText = NormalizedPlaintext(plaintext);
        var sqrt = Math.Sqrt(normalizedText.Length);
        var columns = (int)Math.Ceiling(sqrt);
        var paddedText = normalizedText.PadRight((int)(columns * Math.Round(sqrt)), ' ');


        var segments = new List<string>();

        for(var i = 0; i < paddedText.Length; i += columns)
        {
            segments.Add(paddedText.Substring(i, columns));
        }

        return segments;
    }

    public static string Encoded(string plaintext)
    {
        var segments = PlaintextSegments(plaintext).ToArray();
        var columns = segments[0].Length;
        var encoded = string.Empty;

        

        for(var r = 0; r < columns; r++)
        {
            for(var c = 0; c < segments.Length; c++)
            {
                encoded += segments[c][r];
            }

            if(r < columns - 1) encoded += ' ';
        }
        
        return encoded;

    }

    public static string Ciphertext(string plaintext)
    {
        var normalizedText = NormalizedPlaintext(plaintext);

        var cipherText = normalizedText.Length > 2 ? Encoded(normalizedText) : normalizedText;
        return cipherText;
    }
}