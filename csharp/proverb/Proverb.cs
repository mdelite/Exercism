using System;
using System.Collections.Generic;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        var proverb = new List<string>();

        for(var i = 0; i < subjects.Length - 1; i++)
        {
            proverb.Add($"For want of a {subjects[i]} the {subjects[i + 1]} was lost.");
        }

        if(subjects.Length > 0) proverb.Add($"And all for the want of a {subjects[0]}.");

        return proverb.ToArray();
    }
}