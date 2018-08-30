using System;
using System.Linq;

public static class AtbashCipher
{
    public static string Encode(string plainValue) => string.Concat(plainValue
            .Select(x => char.ToLowerInvariant(x))
            .Where(x => char.IsLetterOrDigit(x))
            .Select(Code))
            .Group();

    private static string Group(this string encoded) => string.Concat(encoded
            .Select((x, i) => i)
            .Where(i => i % 5 == 0)
            .Select(i => encoded.Substring(i, encoded.Length - i >= 5 ? 5 : encoded.Length - i) + " "))
            .Trim();

    private static char Code(char arg)
    {
        if(char.IsDigit(arg)) return arg;

        var num = arg - 'a';
        return (char)('z' - num);
    }

    public static string Decode(string encodedValue) => string.Concat(string.Concat(encodedValue.Split(' '))
            .Select(Code));
}
