using System;
using System.Linq;
using System.Collections.Generic;


public static class SecretHandshake
{
    [Flags]
    private enum Handshakes
    {
        none = 0,
        wink = 1,
        double_blink = 2,
        close_your_eyes = 4,
        jump = 8,
        reverse = 16
    }
    
    public static string[] Commands(int commandValue)
    {
        var commands = (Handshakes)commandValue;

        var actions = Enum.GetValues(typeof (Handshakes))
            .Cast<Handshakes>()
            .Where(x => commands.HasFlag(x) && x != Handshakes.reverse && x != Handshakes.none )
            .Select(x => x.ToString().Replace('_', ' '));
        
        if(commands.HasFlag(Handshakes.reverse)) return actions.Reverse().ToArray();

        return actions.ToArray();
    }
}
