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
    private List<Plant> _row1;
    private List<Plant> _row2;

    private IList<string> _students;

    public KindergartenGarden(string diagram)
    {
        var students = new[] { "Alice", "Bob", "Charlie", "David", "Eve",
            "Fred", "Ginny", "Harriet", "Ileana", "Joseph",
             "Kincaid", "Larry"};
             
        _students = students.ToList();

        var r1 = diagram.Split("\n")[0];
        var r2 = diagram.Split("\n")[1];

        var row1 = new List<Plant>();
        var row2 = new List<Plant>();
        for(var i = 0; i < r1.Length; i++)
        {
            row1.Add(GetPlant(r1[i]));
            row2.Add(GetPlant(r2[i]));
        }
        
        _row1 = row1;
        _row2 = row2;

    }

    public KindergartenGarden(string diagram, IEnumerable<string> students) : this(diagram)
    {
        _students = students.OrderBy(x => x).ToList();
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var studentIndex = _students.IndexOf(student);
        var row1 = new List<Plant>();
        var row2 = new List<Plant>();

        for(var i = studentIndex * 2; i < studentIndex * 2 + 2; i++)
        {
            row1.Add(_row1[i]);
            row2.Add(_row2[i]);
        }

        row1.AddRange(row2);

        return row1.ToArray();
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
                throw new ArgumentOutOfRangeException();
        }
    }
}