using System;
using System.Linq;
using System.Collections.Generic;

public static class OcrNumbers
{
    public static string Convert(string input)
    {
        var lines = input.Split("\n");
        if (lines.Count() < 4 || lines[0].Length % 3 != 0) throw new ArgumentException();

        var digits = Enumerable.Range(0, lines[0].Length / 3)
            .Select(y => Enumerable.Range(0, 4)
                .Select(x => lines[x].Substring(y * 3, 3)))
            .Select(x => GetChar(x));

        return string.Join("", digits);
    }

    private static char GetChar(IEnumerable<string> text)
    {
        var s = string.Join("\n", text);
        switch (s)
        {
            case Digits.Zero:
                return '0';
            case Digits.One:
                return '1';
            case Digits.Two:
                return '2';
            case Digits.Three:
                return '3';
            case Digits.Four:
                return '4';
            case Digits.Five:
                return '5';
            case Digits.Six:
                return '6';
            case Digits.Seven:
                return '7';
            case Digits.Eight:
                return '8';
            case Digits.Nine:
                return '9';
            default:
                return '?';
        }
    }

    private static class Digits
    {
        public const string Zero =
            " _ \n" +
            "| |\n" +
            "|_|\n" +
            "   ";
        public const string One =
            "   \n" +
            "  |\n" +
            "  |\n" +
            "   ";
        public const string Two =
            " _ \n" +
            " _|\n" +
            "|_ \n" +
            "   ";
        public const string Three =
            " _ \n" +
            " _|\n" +
            " _|\n" +
            "   ";
        public const string Four =
            "   \n" +
            "|_|\n" +
            "  |\n" +
            "   ";
        public const string Five =
            " _ \n" +
            "|_ \n" +
            " _|\n" +
            "   ";
        public const string Six =
            " _ \n" +
            "|_ \n" +
            "|_|\n" +
            "   ";
        public const string Seven =
            " _ \n" +
            "  |\n" +
            "  |\n" +
            "   ";
        public const string Eight =
            " _ \n" +
            "|_|\n" +
            "|_|\n" +
            "   ";
        public const string Nine =
            " _ \n" +
            "|_|\n" +
            " _|\n" +
            "   ";
    }
}