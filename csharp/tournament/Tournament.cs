using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public static class Tournament
{
    public static string resultString => "{0,-30} | {1,2} | {2,2} | {3,2} | {4,2} | {5,2}";
    public static void Tally(Stream inStream, Stream outStream)
    {
        var teams = new Dictionary<string, TeamResults>();

        using (var sr = new StreamReader(inStream))
        {
            while (!sr.EndOfStream)
            {
                var match = sr.ReadLine().Split(';');

                teams.TryAdd(match[0], new TeamResults());
                teams.TryAdd(match[1], new TeamResults());

                switch (match[2])
                {
                    case "win":
                        teams[match[0]].Wins++;
                        teams[match[1]].Losses++;
                        break;
                    case "loss":
                        teams[match[0]].Losses++;
                        teams[match[1]].Wins++;
                        break;
                    case "draw":
                        teams[match[0]].Draws++;
                        teams[match[1]].Draws++;
                        break;
                }
            }
        }

        using (var sw = new StreamWriter(outStream))
        {
            sw.Write(string.Format(resultString, "Team", "MP", "W", "D", "L", "P"));
            teams.OrderByDescending(x => x.Value.Points).ThenBy(x => x.Key)
                .ToList()
                .ForEach(x =>
                {
                    sw.Write("\n");
                    sw.Write(x.Value.Results(x.Key, resultString));
                });
        }
    }
}

public class TeamResults
{
    public int Wins { set; get; }
    public int Losses { set; get; }
    public int Draws { set; get; }
    public int Matches => Wins + Losses + Draws;
    public int Points => Wins * 3 + Draws;
    public string Results(string name, string resultsFormat) => string.Format(resultsFormat, name, Matches, Wins, Draws, Losses, Points);
}