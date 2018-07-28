using System;
using System.Text.RegularExpressions;

public class Markdown
{
    public static string Parse(string markdown)
    {
        var lines = markdown.Split('\n');
        var result = "";
        var isList = false;

        foreach(var line in lines)
        {
            switch(line.Substring(0,1))
            {
                case "#":
                    result += ParseHeader(line, isList);
                    break;
                case "*":
                    result += ParseList(line, ref isList);
                    break;
                default:
                    result += ParseParagraph(line, isList);
                    break;
            }
        }

        if (isList) result += "</ul>";
        
        return result; 
    }

    private static string ParseParagraph(string line, bool isList)
    {
        var innerHtml = ParseText(line);
        if (!isList)
        {
            innerHtml = Wrap(innerHtml, "p");
        }
        else
        {
            innerHtml = "</ul>" + innerHtml;
        }

        return innerHtml;
    }

    private static string ParseList(string line, ref bool isList)
    {
        var innerHtml = ParseText(line.Substring(2));
        innerHtml = Wrap(innerHtml, "li");
        if (!isList)
        {
            isList = true;
            innerHtml = "<ul>" + innerHtml;
        }

        return innerHtml;
    }

    private static string ParseHeader(string line, bool isList)
    {
        var count = HeaderCount(line);
        var headerTag = "h" + count;

        var innerHtml = Wrap(line.Substring(count + 1), headerTag);
        if (isList) innerHtml = "</ul>" + innerHtml;

        return innerHtml;
    }

    private static int HeaderCount(string markdown)
    {
        var count = 0;

        for (int i = 0; i < markdown.Length; i++)
        {
            if (markdown[i] == '#')
            {
                count++;
            }
            else
            {
                break;
            }
        }

        return count;
    }

    private static string Wrap(string text, string tag) => $"<{tag}>{text}</{tag}>";

    private static string Parse(string markdown, string delimiter, string tag)
    {
        var pattern = $"{delimiter}(.+){delimiter}";
        var replacement = $"<{tag}>$1</{tag}>";
        return Regex.Replace(markdown, pattern, replacement);
    }

    private static string ParseText(string markdown)
    {
        markdown = Parse(markdown, "__", "strong");
        markdown = Parse(markdown, "_", "em");

        return markdown;
    }
}