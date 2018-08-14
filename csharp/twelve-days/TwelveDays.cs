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
        "first", "second", "third", "fourth", "fifth", "sixth",
        "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth"
    };

    public static string Recite(int verseNumber) =>
        $"On the {days[verseNumber - 1]} day of Christmas my true love gave to me, {TheseGifts(verseNumber)}.";

    private static string TheseGifts(int verseNumber) => Enumerable.Range(0, verseNumber)
            .Reverse()
            .Select(x => ((x == 0 && verseNumber > 1) ? "and " : "") + gifts[x])
            .Aggregate((a, b) => $"{a}, {b}");

    public static string Recite(int startVerse, int endVerse) => Enumerable.Range(startVerse, endVerse - startVerse + 1)
            .Select(verse => Recite(verse))
            .Aggregate((a, b) => $"{a}\n{b}");
}