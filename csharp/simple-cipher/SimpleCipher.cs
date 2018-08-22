using System;
using System.Linq;
using System.Collections.Generic;

public class SimpleCipher
{
    public SimpleCipher()
    {
        var rand = new Random();
        Key = string.Concat(Enumerable.Range(1, 100)
            .Select(x => (char)rand.Next('a', 'z' + 1)));
    }

    public SimpleCipher(string key)
    {
        if(key == "" || !key.All(char.IsLower)) throw new ArgumentException($"{nameof(key)} must be one or more lowercase letters");
        Key = key;
    }
    
    public string Key 
    {
        get; private set;
    }

    public string Encode(string plaintext) 
    {
        return Shift(plaintext,(x, y) => (x + y));
    } 

    public string Decode(string ciphertext)
    {
        return Shift(ciphertext, (x, y) => (x - y));
    }

    int CanonicalModulo(int number, int divisor)
    {
        return ((number % divisor) + divisor) % divisor;
    }

    string Shift(string text, Func<int, int, int> func)
    {
        var key = string.Concat(Enumerable.Repeat(Key, (int)Math.Ceiling((double)text.Length / Key.Length)));
        return string.Concat(text.Zip(key, (a, b) => (char)('a' + CanonicalModulo(func(a - 'a', b - 'a'), 26))));
    }
}
