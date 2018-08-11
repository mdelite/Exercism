using System;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        char Rotate(char c)
        {
            if(!char.IsLetter(c)) return c;
            
            var firstLetter = char.IsUpper(c) ? 'A' : 'a';

            return (char)(firstLetter + (c - firstLetter + shiftKey) % 26);
        }

        return new string((text.Select(Rotate).ToArray()));
    }
}