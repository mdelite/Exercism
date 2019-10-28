using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private string[] rows;
    private int width;
    private int heigth;
    ValueTuple<int, int>[] moves = { (1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (-1, -1), (1, -1), (-1, 1) };

    public WordSearch(string grid)
    {
        rows = grid.Split("\n");
        width = rows[0].Length;
        heigth = rows.Length;
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var dict = new Dictionary<string, ((int, int), (int, int))?>();

        foreach (var word in wordsToSearchFor)
        {
            var loc = Find(word);
            dict.Add(word, loc);
        }
        return dict;
    }

    private ((int, int), (int, int))? Find(string word)
    {
        var output = (
            from i in Enumerable.Range(0, width)
            from j in Enumerable.Range(0, heigth)
            from move in moves
            select String.Concat(
                from c in Enumerable.Range(0, word.Length)
                select (i + move.Item1 * c, j + move.Item2 * c) into position
                where position.Item1 >= 0 && position.Item1 < width
                where position.Item2 >= 0 && position.Item2 < heigth
                select rows[position.Item2][position.Item1]
                ) == word ?
                Tuple.Create((i + 1, j + 1), (i + 1 + (word.Length - 1) * move.Item1, j + 1 + (word.Length - 1) * move.Item2))
                : null into k
            where k != null
            select k
            ).FirstOrDefault();

        if (output != null)
        {
            return ((output.Item1.Item1, output.Item1.Item2), (output.Item2.Item1, output.Item2.Item2));
        }
        return null;
    }
}