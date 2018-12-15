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
    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        return new LedgerBuilder(currency, locale, entries).Formatted;
    }

    public static LedgerEntry CreateEntry(string date, string desc, int chng)
    {
        return new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0f);
    }
}

internal class LedgerBuilder
{
    private CultureInfo _culture;
    private StringBuilder _formatted;
    private LedgerEntry[] _entries;

    public string Formatted => _formatted.ToString();

    public LedgerBuilder(string currency, string locale, LedgerEntry[] entries)
    {
        _culture = CreateCulture(currency, locale);
        _formatted = new StringBuilder(PrintHead());
        _entries = entries;

        if (_entries.Length > 0)
        {
            var entriesForOutput = Sort();

            for (var i = 0; i < entriesForOutput.Count(); i++)
            {
                _formatted.Append("\n" + PrintEntry( entriesForOutput.Skip(i).First()));
            }
        }
    }

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        string curSymb = null;
        int curNeg = 0;
        string datPat = null;

        if (cur != "USD" && cur != "EUR")
        {
            throw new ArgumentException("Invalid currency");
        }
        else
        {
            if (loc != "nl-NL" && loc != "en-US")
            {
                throw new ArgumentException("Invalid currency");
            }

            if (cur == "USD")
            {
                if (loc == "en-US")
                {
                    curSymb = "$";
                    datPat = "MM/dd/yyyy";
                }
                else if (loc == "nl-NL")
                {
                    curSymb = "$";
                    curNeg = 12;
                    datPat = "dd/MM/yyyy";
                }
            }

            if (cur == "EUR")
            {
                if (loc == "en-US")
                {
                    curSymb = "€";
                    datPat = "MM/dd/yyyy";
                }
                else if (loc == "nl-NL")
                {
                    curSymb = "€";
                    curNeg = 12;
                    datPat = "dd/MM/yyyy";
                }
            }
        }

        var culture = new CultureInfo(loc);
        culture.NumberFormat.CurrencySymbol = curSymb;
        culture.NumberFormat.CurrencyNegativePattern = curNeg;
        culture.DateTimeFormat.ShortDatePattern = datPat;
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

    private string Date( DateTime date) => date.ToString("d", _culture);

    private static string Description(string desc)
    {
        if (desc.Length > 25)
        {
            var trunc = desc.Substring(0, 22);
            trunc += "...";
            return trunc;
        }

        return desc;
    }

    private string Change(float cgh)
    {
        return cgh < 0.0 ? cgh.ToString("C", _culture) : cgh.ToString("C", _culture) + " ";
    }

    private string PrintEntry(LedgerEntry entry)
    {
        var formatted = "";
        var date = Date(entry.Date);
        var description = Description(entry.Desc);
        var change = Change(entry.Chg);

        formatted += date;
        formatted += " | ";
        formatted += string.Format("{0,-25}", description);
        formatted += " | ";
        formatted += string.Format("{0,13}", change);

        return formatted;
    }

    private IEnumerable<LedgerEntry> Sort()
    {
        var neg = _entries.Where(e => e.Chg < 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);
        var post = _entries.Where(e => e.Chg >= 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);

        var result = new List<LedgerEntry>();
        result.AddRange(neg);
        result.AddRange(post);

        return result;
    }
}
