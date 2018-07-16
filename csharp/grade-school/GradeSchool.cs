using System;
using System.Collections.Generic;
using System.Linq;

public class School
{
    private List<Tuple<string, int>> _roster = new List<Tuple<string, int>>();

    public void Add(string student, int grade)
    {
        _roster.Add(new Tuple<string,int>(student,grade));
    }

    public IEnumerable<string> Roster()
    {
        var roster = new List<string>();
        var grades = _roster
            .GroupBy(x => x.Item2)
            .Select(x => x.First())
            .Select(x => x.Item2)
            .ToList();
        
        grades.Sort();

        var list = new List<string>();
        foreach(var grade in grades)
        {

            roster.AddRange(Grade(grade));
        }
        return roster;
    }

    public IEnumerable<string> Grade(int grade)
    {
        var classRoster = _roster
            .Where(x => x.Item2 == grade)
            .Select(x => x.Item1)
            .ToList();

        classRoster.Sort();

        return classRoster;
    }
}

public class Student
{
    private string _name;
    private int _grade;
    
}