using System;
using System.Collections.Generic;
using System.Linq;

public static class FoodChain
{
    private static readonly Diet[] Verses = 
    {
        new Diet(){ Food = "fly", Reaction = "I don't know why she swallowed the fly. Perhaps she'll die."},
        new Diet(){ Food = "spider", Reaction = "It wriggled and jiggled and tickled inside her."},
        new Diet(){ Food = "bird", Reaction = "How absurd to swallow a bird!"},
        new Diet(){ Food = "cat", Reaction = "Imagine that, to swallow a cat!"},
        new Diet(){ Food = "dog", Reaction = "What a hog, to swallow a dog!"},
        new Diet(){ Food = "goat", Reaction = "Just opened her throat and swallowed a goat!"},
        new Diet(){ Food = "cow", Reaction = "I don't know how she swallowed a cow!"},
        new Diet(){ Food = "horse", Reaction = "She's dead, of course!"},
    };
    public static string Recite(int verseNumber)
    {
        var verseIndex = verseNumber - 1;
        var verse = $"I know an old lady who swallowed a {Verses[verseIndex].Food}.\n{Verses[verseIndex].Reaction}";

        for(var v = verseIndex; v > 0 && v < Verses.Length - 1; v--)
        {
            verse += $"\nShe swallowed the {Verses[v].Food} to catch the {Verses[v -1].Food}.";

            if(v == 2)
            {
                verse = verse.TrimEnd('.') + Verses[1].Reaction.Replace("It", " that");
            } 
        }

        if(verseIndex > 0 && verseIndex < Verses.Length - 1)
        {
            verse += $"\n{Verses[0].Reaction}";
        }
        
        return verse;
    }

    public static string Recite(int startVerse, int endVerse) => string.Join("\n\n", Enumerable.Range(startVerse, endVerse - startVerse + 1)
            .Select(i => Recite(i)));
}
public class Diet
{
    public string Food {set; get;}
    public string Reaction { set; get;}
}

