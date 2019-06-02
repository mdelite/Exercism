using System;
using System.Collections.Generic;

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
        var numbers = new List<uint>();
        var number = 0x00u;
        var n = 0;
        var more = 0x00u;
        while(n < bytes.Length)
        {
            var b = bytes[n++];
            more = b & 0x80u;
            number = (number << 7) | (b & 0x7fu);
            if(more != 0x80u)
            {
                numbers.Add(number);
                number = 0x00u;
            }
        }
        if(more != 0x00u) throw new InvalidOperationException();
        
        return numbers.ToArray();
    }
}