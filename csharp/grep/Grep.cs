using System;
using System.IO;
using System.Text;

public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        var sb = new StringBuilder();
        var caseInsensitive = flags.Contains("-i");
        var fileMatch = flags.Contains("-l");
        var lineMatch = flags.Contains("-x");
        var tagNumber = flags.Contains("-n");
        var inverted = flags.Contains("-v");

        var testPattern = caseInsensitive ? pattern.ToLowerInvariant() : pattern;

        foreach(var file in files)
        {
            var reader = new StreamReader(file);
            string line;
            var lineNumber = 0;

            while((line = reader.ReadLine()) != null)
            {
                lineNumber++;

                var tag = tagNumber ? $"{lineNumber}:" : "";
                if(LineMatch(line))
                {
                    if(fileMatch)
                    {
                        sb.Append($"{(sb.Length > 0 ? "\n" : "")}{file}");
                        reader.ReadToEnd();
                    }
                    else
                    {
                        sb.Append($"{(sb.Length > 0 ? "\n" : "")}{(files.Length > 1 ? $"{file}:" : "")}{tag}{line}");
                    }
                }
            }
            reader.Close();
        }

        return sb.ToString();

        bool LineMatch(string text)
        {   
            var testText = caseInsensitive ? text.ToLowerInvariant() : text;
            var isMatch = lineMatch ? testText == testPattern : testText.Contains(testPattern);
            return inverted ? !isMatch : isMatch;
        }
    }

}