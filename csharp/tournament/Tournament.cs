using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        using (var sw = new StreamWriter(outStream))
        {
            sw.NewLine = "\n";
            sw.Write(OutRow("Team", "MP", "W", "D", "L", "P"));
            
            var teams = new Teams();

            using (var sr = new StreamReader(inStream))
            {
                while (sr.Peek() > -1)
                {
                    var match = sr.ReadLine().Split(';');
                    var homeTeam = new Team(match[0]);
                    var awayTeam = new Team(match[1]);
                    var result = match[2];

                    switch (result)
                    {
                        case "win":
                            homeTeam.Wins++;
                            awayTeam.Losses++;
                            break;
                        case "loss":
                            homeTeam.Losses++;
                            awayTeam.Wins++;
                            break;
                        case "draw":
                            homeTeam.Draws++;
                            awayTeam.Draws++;
                            break;
                        default:
                            throw new NotImplementedException();
                    }

                    teams.Add(homeTeam);
                    teams.Add(awayTeam);
                }
            }

            teams.OrderByDescending(x => x.Points).ThenBy(x => x.Name).ToList().ForEach(x => { 
                sw.WriteLine();
                sw.Write(OutRow(x.Name,x.Matches.ToString(),x.Wins.ToString(),x.Draws.ToString(),x.Losses.ToString(),x.Points.ToString()));
            });
        }
    }

    public static string OutRow(string team, string matches, string wins, string draws, string losses, string points)
    {
        return $"{team,-30} | {matches,2} | {wins,2} | {draws,2} | {losses,2} | {points,2}";
    }
}

public class Team : IEquatable<Team>
{
    public Team(string name) => this.Name = name;

    public string Name { set; get; }
    public int Wins { set; get; }
    public int Losses { set; get; }
    public int Draws { set; get; }

    public int Matches => Wins + Losses + Draws;
    public int Points => Wins * 3 + Draws;

    public  bool Equals(Team other)
    {
        return this.Name.Equals(other.Name);
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
    }

    internal void Update(Team team)
    {
        this.Wins += team.Wins;
        this.Losses += team.Losses;
        this.Draws += team.Draws;
    }
}

public class Teams : HashSet<Team>
{
    public new void Add(Team team)
    {
        var res = base.Add(team);
        if(!res)
        {
            this.Single(x => x.Name == team.Name).Update(team);
        }
    }
}