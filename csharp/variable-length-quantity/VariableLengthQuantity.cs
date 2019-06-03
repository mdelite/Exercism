using System;
using System.Collections.Generic;
using System.Linq;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers) => numbers.SelectMany(x => Bytes(x).Reverse()).ToArray();
    public static uint[] Decode(uint[] bytes) => Combine(bytes).ToArray();

    private static IEnumerable<uint> Combine(uint[] bytes)
    {
        if ((bytes.Last() & 0x80u) > 0) throw new InvalidOperationException();
        var number = 0x00u;
        foreach (var b in bytes)
        {
            number = (number << 7) | (b & 0x7fu);
            if ((b & 0x80u) == 0)
            {
                yield return number;
                number = 0x00u;
            }
        }
    }

    public static IEnumerable<uint> Bytes(uint number)
    {
        var more = 0x00u;
        do
        {
            yield return (number & 0x7fu) | more;
            number >>= 7;
            more = 0x80u;
        } while (number > 0);
    }
}