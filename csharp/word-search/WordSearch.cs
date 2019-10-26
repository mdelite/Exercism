using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private string[] rows;
    private int width;
    private int heigth;

    public WordSearch(string grid)
    {
        rows = grid.Split("\n");
        width = rows[0].Length;
        heigth = rows.Length;
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        throw new NotImplementedException();
    }

}