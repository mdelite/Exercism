using System;
using System.Text.RegularExpressions;

public class Markdown
{
    private static bool _isList = false;

    public static string Parse(string markdown)
    {
        var lines = markdown.Split('\n');
        var result = "";
        _isList = false;

        for (int i = 0; i < lines.Length; i++)
        {
            var lineResult = ParseLine(lines[i]);
            result += lineResult;
        }

        if (_isList)
        {
            return result + "</ul>";
        }
        else
        {
            return result;
        }
    }

    private static string ParseLine(string markdown)
    {
        var result = ParseHeader(markdown);

        if (result == null)
        {
            result = ParseLineItem(markdown);
        }

        if (result == null)
        {
            result = ParseParagraph(markdown);
        }

        if (result == null)
        {
            throw new ArgumentException("Invalid markdown");
        }

        return result;
    }

    private static string Wrap(string text, string tag) => $"<{tag}>{text}</{tag}>";
    private static bool IsTag(string text, string tag) => text.StartsWith($"<{tag}>");

    private static string Parse(string markdown, string delimiter, string tag)
    {
        var pattern = $"{delimiter}(.+){delimiter}";
        var replacement = $"<{tag}>$1</{tag}>";
        return Regex.Replace(markdown, pattern, replacement);
    }

    private static string ParseText(string markdown, bool list)
    {
        markdown = Parse(markdown, "__", "strong");
        markdown = Parse(markdown, "_", "em");

        if (list)
        {
            return markdown;
        }
        else
        {
            return Wrap(markdown, "p");
        }
    }

    private static string ParseHeader(string markdown)
    {
        var count = 0;

        for (int i = 0; i < markdown.Length; i++)
        {
            if (markdown[i] == '#')
            {
                count += 1;
            }
            else
            {
                break;
            }
        }

        if (count == 0)
        {
            return null;
        }

        var headerTag = "h" + count;
        var headerHtml = Wrap(markdown.Substring(count + 1), headerTag);

        if (_isList)
        {
            return "</ul>" + headerHtml;
        }
        else
        {
            return headerHtml;
        }
    }

    private static string ParseLineItem(string markdown)
    {
        if (markdown.StartsWith("*"))
        {
            var innerHtml = Wrap(ParseText(markdown.Substring(2), true), "li");

            if (_isList)
            {
                return innerHtml;
            }
            else
            {
                _isList = true;
                return "<ul>" + innerHtml;
            }
        }

        return null;
    }

    private static string ParseParagraph(string markdown)
    {
        if (!_isList)
        {
            return ParseText(markdown, _isList);
        }
        else
        {
            return "</ul>" + ParseText(markdown, _isList);
        }
    }


}