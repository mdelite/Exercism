using System;
using System.Collections.Generic;
using System.Linq;

public static class TwelveDays
{
    private static string[] gifts = new []
    {
        "a Partridge in a Pear Tree",
        "two Turtle Doves",
        "three French Hens",
        "four Calling Birds",
        "five Gold Rings",
        "six Geese-a-Laying",
        "seven Swans-a-Swimming",
        "eight Maids-a-Milking",
        "nine Ladies Dancing",
        "ten Lords-a-Leaping",
        "eleven Pipers Piping",
        "twelve Drummers Drumming"
    };

    private static string[] days = new[]
    {
        "first",
        "second",
        "third",
        "fourth",
        "fifth",
        "sixth",
        "seventh",
        "eighth",
        "ninth",
        "tenth",
        "eleventh",
        "twelfth"
    };
    
    public static string Recite(int verseNumber)
    {
        return $"On the {days[verseNumber - 1]} day of Christmas my true love gave to me, {TheseGifts(verseNumber)}.";
    }

    private static string TheseGifts(int verseNumber)
    {
        if(verseNumber == 1) return gifts[0];

        var theseGifts = Enumerable.Range(0, verseNumber)
            .Reverse()
            .Select(x => gifts[x])
            .SkipLast(1)
            .Aggregate((a, b) => $"{a}, {b}");

        return $"{theseGifts}, and {gifts[0]}";
    }

    public static string Recite(int startVerse, int endVerse)
    {
        return Enumerable.Range(startVerse, endVerse - startVerse + 1)
            .Select(verse => Recite(verse))
            .Aggregate((a, b) => $"{a}\n{b}");
    }
}