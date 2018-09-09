using System;
using System.Linq;
using System.Collections.Generic;
public static class BracketPush
{
    public static bool IsPaired(string input)
    {
        var brackets = new Dictionary<char, char>() {{'[', ']'}, {'{', '}'}, {'(', ')'}};
        var stack = new Stack<char>();

        foreach(var c in input)
        {
            if(brackets.ContainsKey(c)) 
            {
                stack.Push(brackets[c]);
            }
            else if(brackets.ContainsValue(c))
            {
                if(stack.Count == 0 || stack.Pop() != c) return false;
            }
        }
        return stack.Count == 0;
    }
}
