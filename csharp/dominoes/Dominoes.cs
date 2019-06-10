using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        if (dominoes.Count() == 0) return true;
        
        var chain = Connect(dominoes).ToArray();
        return chain.Count() > 1 ? false : chain[0].Item1 == chain[0].Item2;
    }

    private static IEnumerable<(int, int)> Connect(IEnumerable<(int, int)> dominoes)
    {
        if (dominoes.Count() == 1) return dominoes;
        var chain = dominoes;

        var matches = dominoes.Skip(1).Where(x => x.Item1 == dominoes.First().Item2 || x.Item2 == dominoes.First().Item2);
        foreach(var match in matches)
        {
            var links = dominoes.Skip(1).ToList();
            links.Remove(match);
            var head = (dominoes.First().Item1, dominoes.First().Item2 == match.Item1 ? match.Item2 : match.Item1 );

            chain = Connect(links.Prepend(head));

            if(chain.Count() == 1) return chain;
        }

        return chain;
    }
}