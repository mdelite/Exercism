using System;
using System.Collections.Generic;
using System.Linq;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var chunks = new List<uint>();
        foreach (var n in numbers)
        {
            var stack = new Stack<uint>();
            var more = 0x00u;
            var number = n;
            do
            {
                var v = (number & 0x7fu) | more;
                stack.Push(v);
                number = number >> 7;
                more = 0x80u;
            } while (number > 0);
            chunks.AddRange(stack);
        }

        return chunks.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}