using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private string[] _rows;
    public WordSearch(string grid)
    {
        _rows = grid.Split("\n");
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        return  wordsToSearchFor.ToDictionary( x => x, y => GetCoords(y));
    }
    private ((int, int), (int, int))? GetCoords( string word)
    {
        for(var r = 0; r < _rows.Length; r++)
        {
            var found = _rows[r].IndexOf(word);
            if(found >= 0)
            {
                return ((found + 1, r+ 1), (found + word.Length, r+1));
            }
        }
        return null;
    }
}