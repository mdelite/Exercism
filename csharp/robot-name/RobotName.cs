using System;

public class Robot
{
    private string _name;

    public Robot() => Reset();

    public string Name
    {
        get => _name;        
    }

    public void Reset()
    {
        var name = string.Empty;

        var rnd = new Random();
        name += (char)('A' + rnd.Next(26));
        name += (char)('A' + rnd.Next(26));
        name += rnd.Next(1000).ToString("D3");

        _name = name;
    }
}