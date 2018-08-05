using System;
using System.Text;

public static class BeerSong
{
    public static string Recite(int startBottles, int rounds)
    {
        var song = new StringBuilder();
        var bottles = startBottles;
        
        for(int round = 1; round <= rounds; round++)
        {
            var verse = $"{ThisManyBeer(bottles).Upper()} on the wall, {ThisManyBeer(bottles)}.\n";
            verse += $"{DoSomethingWithThisMany(ref bottles)}, {ThisManyBeer(bottles)} on the wall.";

            if(round < rounds) verse +="\n\n";    // Is another round coming? Give it space.

            song.Append(verse);
        }

        return song.ToString();
    }

    private static string ThisManyBeer(int bottles)
    {
        if(bottles == 0) return "no more bottles of beer";

        return $"{bottles} bottle{(bottles == 1 ? "" : "s" )} of beer";
    }

    private static string DoSomethingWithThisMany(ref int bottles)
    {
        var something = "";

        if(bottles > 0)
        {
            something = $"Take {(bottles > 1 ? "one" : "it" )} down and pass it around";
            bottles--;
        }
        else
        {
            something = "Go to the store and buy some more";
            bottles = 99;
        }

        return something;
    }

    private static string Upper(this string s) => Char.ToUpper(s[0]) + s.Substring(1);
}