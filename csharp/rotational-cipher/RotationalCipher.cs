using System;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        return new string((text.Select(x => Rotate(x, shiftKey)).ToArray()));
    }

    private static char Rotate(char c, int shiftKey)
    {
        if(!char.IsLetter(c)) return c;
        
        var shifted = c + shiftKey;
        
        while((char.IsLower(c) && shifted > 'z') || (char.IsUpper(c) && shifted > 'Z'))
        {
            shifted -= 26;
        }

        return (char)shifted;
    }
}