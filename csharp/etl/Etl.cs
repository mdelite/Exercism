using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var dict = new SortedDictionary<string, int>();

        foreach(var key in old.Keys)
        {
            foreach(var str in old[key])
            {
                dict.Add(str.ToLowerInvariant(), key);
            }
        }

        return new Dictionary<string, int>(dict);
    }
}