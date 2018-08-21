using System;
using System.Linq;
using System.Collections.Generic;

public class SimpleCipher
{
    int[] _key;

    public SimpleCipher()
    {
        var rand = new Random();
        _key = Enumerable.Range(1, 100)
            .Select(x => rand.Next(26))
            .ToArray();
    }

    public SimpleCipher(string key)
    {
        if(key == "" || !key.All(char.IsLower)) throw new ArgumentException($"{nameof(key)} must be one or more lowercase letters");
        _key = key
            .Select(x => x - 'a')
            .ToArray();
    }
    
    public string Key 
    {
        get
        {
            return new string(_key.Select(x => (char)(x + 'a')).ToArray());
        }
    }

    public string Encode(string plaintext) => new string(plaintext
            .Zip(_key.Stretch(plaintext.Length), (x, y) => ShiftChar(x, y))
            .ToArray());

    public string Decode(string ciphertext) => new string(ciphertext
            .Zip(_key.Stretch(ciphertext.Length), (x, y) => ShiftChar(x, -y))
            .ToArray());

    private char ShiftChar(char c, int shift)
    {
        var n = c + shift;
        if(n > 'z')
        {
            n -= 26;
        } 
        else if(n < 'a')
        {
            n += 26;
        }
        return (char)n;
    }
}

static class Extensions
{
        public static IEnumerable<T> Stretch<T>(this IEnumerable<T> key, int length)
    {
        var newKey = key.ToList();

        while(newKey.Count() < length)
        {
            newKey.AddRange(key);
        }
        return newKey;
    }

}