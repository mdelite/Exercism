using System;
using System.Linq;

public class SimpleCipher
{
    public SimpleCipher()
    {
        var rand = new Random();
        Key = new string (Enumerable.Range(1, 100)
            .Select(x => (char)('a' + rand.Next(26)))
            .ToArray());
    }

    public SimpleCipher(string key)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
    
    public string Key 
    {
        get; private set;
    }

    public string Encode(string plaintext)
    {
        return new string (plaintext.ToLowerInvariant()
            .Zip(Key, (x, y) => ShiftChar(x, y))
            .ToArray());
    }

    public string Decode(string ciphertext)
    {
        return new string(ciphertext
            .Zip(Key, (x, y) => DecodeChar(x, y))
            .ToArray());
    }

    private char ShiftChar(char c, char key)
    {
        var n = c + key - 'a';
        return n > 'z' ? (char)(n - 26) : (char)n;
    }

    private char DecodeChar(char c, char key)
    {
        var n = c - key + 'a';
        return n < 'a' ? (char)(n + 26) : (char)n;
    }
}