using System;
using System.Linq;
using System.Collections.Generic;


public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        var actions = new List<string>();
        
        var i = 1;
        while(i < 16)
        {
            if((commandValue & i) > 0)
            {
                actions.Add(GetAction(i));  
            }
            i = i << 1;
        }

        if((commandValue & 16) > 0) actions.Reverse();
        return actions.ToArray();
    }

    private static string GetAction(int i)
    {
        switch(i)
        {
            case 1:
                return "wink";
            case 2:
                return "double blink";
            case 4:
                return "close your eyes";
            case 8:
                return "jump";
            default:
                throw new ArgumentOutOfRangeException($"No action for '{i}' is defined.");
        }
    }
}
