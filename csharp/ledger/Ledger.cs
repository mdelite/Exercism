using System;
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

    public string Formatted(CultureInfo culture)
    {
        var date = Date.ToString("d", culture);
        var description = Desc.Length > 25 ? $"{Desc.Substring(0, 22)}..." : Desc;
        var change = Chg < 0.0 ? Chg.ToString("C", culture) : Chg.ToString("C", culture) + " ";
        return $"{date} | {description.PadRight(25)} | {change.PadLeft(13)}";
    }
}

public static class Ledger
{
    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var culture = CreateCulture(currency, locale);
        var formatted = new StringBuilder(PrintHead(culture));
        entries
            .OrderBy(x => x.Date)
            .ThenBy(x => x.Desc)
            .ThenBy(x => x.Chg)
            .ToList()
            .ForEach(x => formatted.Append("\n" + x.Formatted(culture)));
        return formatted.ToString();
    }

    private static string PrintHead(CultureInfo culture)
    {
        switch (culture.Name)
        {
            case "en-US":
                return "Date       | Description               | Change       ";
            case "nl-NL":
                return "Datum      | Omschrijving              | Verandering  ";
            default:
                throw new ArgumentException("Invalid locale");
        }
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

    public static LedgerEntry CreateEntry(string date, string desc, int chng) =>
        new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0f);
}
