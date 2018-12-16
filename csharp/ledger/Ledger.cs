using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string desc, float chg)
    {
        Date = date;
        Desc = desc;
        Chg = chg;
    }

    public DateTime Date { get; }
    public string Desc { get; }
    public float Chg { get; }
}

public static class Ledger
{
    public static string Format(string currency, string locale, LedgerEntry[] entries) =>
        new LedgerBuilder(currency, locale, entries).Formatted;

    public static LedgerEntry CreateEntry(string date, string desc, int chng) =>
        new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0f);
}

internal class LedgerBuilder
{
    private CultureInfo _culture;
    private StringBuilder _formatted;

    public string Formatted => _formatted.ToString();

    public LedgerBuilder(string currency, string locale, LedgerEntry[] entries)
    {
        _culture = CreateCulture(currency, locale);
        _formatted = new StringBuilder(PrintHead());
        entries
            .OrderBy(x => x.Date)
            .ThenBy(x => x.Desc)
            .ThenBy(x => x.Chg)
            .ToList()
            .ForEach(x => _formatted.Append("\n" + PrintEntry(x)));
    }

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        var culture = new CultureInfo(loc);

        switch (culture.Name)
        {
            case "en-US":
                culture.NumberFormat.CurrencyNegativePattern = 0;
                culture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
                break;
            case "nl-NL":
                culture.NumberFormat.CurrencyNegativePattern = 12;
                culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                break;
            default:
                throw new ArgumentException("Invalid currency");
        }

        switch (cur)
        {
            case "USD":
                culture.NumberFormat.CurrencySymbol = "$";
                break;
            case "EUR":
                culture.NumberFormat.CurrencySymbol = "€";
                break;
            default:
                throw new ArgumentException("Invalid currency");
        }

        return culture;
    }

    private string PrintHead()
    {
        switch (_culture.Name)
        {
            case "en-US":
                return "Date       | Description               | Change       ";
            case "nl-NL":
                return "Datum      | Omschrijving              | Verandering  ";
            default:
                throw new ArgumentException("Invalid locale");
        }
    }

    private string Date(DateTime date) => date.ToString("d", _culture);

    private static string Description(string desc) => desc.Length > 25 ? $"{desc.Substring(0, 22)}..." : desc;

    private string Change(float cgh) => cgh < 0.0 ? cgh.ToString("C", _culture) : cgh.ToString("C", _culture) + " ";

    private string PrintEntry(LedgerEntry entry) =>
        $"{Date(entry.Date)} | {Description(entry.Desc).PadRight(25)} | {Change(entry.Chg).PadLeft(13)}";
}

