using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{   
    private string _row1;
    private string _row2;

    private IList<string> _students;

    public KindergartenGarden(string diagram)
    {
        //default class roster.
        var students = new[] { "Alice", "Bob", "Charlie", "David", "Eve",
        "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"};
             
        _students = students.ToList();

        _row1 = diagram.Split("\n")[0];
        _row2 = diagram.Split("\n")[1];
    }

    public KindergartenGarden(string diagram, IEnumerable<string> students) : this(diagram)
    {
        _students = students.OrderBy(x => x).ToList();
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var i = _students.IndexOf(student);

        var plants = _row1.Substring(i * 2, 2) + _row2.Substring(i * 2, 2);

        return GetPlants(plants);
    }

    private IEnumerable<Plant> GetPlants(string p)
    {
        var plants = new List<Plant>();

        foreach(var c in p)
        {
            plants.Add(GetPlant(c));
        }

        return plants;
    }

    private Plant GetPlant(char v)
    {
        switch (v)
        {
            case 'V':
                return Plant.Violets;
            case 'G':
                return Plant.Grass;
            case 'R':
                return Plant.Radishes;
            case 'C':
                return Plant.Clover;
            default:
                throw new ArgumentOutOfRangeException($"Plant type '{v}' is not defined.");
        }
    }
}