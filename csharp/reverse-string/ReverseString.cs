using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var reverse = "";

        for(var i = input.Length; i > 0; i--)
        {
            reverse += input[i - 1];
        }

        return reverse;
    }
}