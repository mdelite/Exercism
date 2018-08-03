using System;

public class Robot
{
    private string _name = string.Empty;
    public string Name
    {
        get
        {
            if(_name == string.Empty) Reset();
            return _name;
        }
    }

    public void Reset()
    {
        var rnd = new Random();
        var name = string.Empty;

        name += (char)('A' + rnd.Next(26));
        name += (char)('A' + rnd.Next(26));
        name += rnd.Next(1000).ToString("D3");

        _name = name;
    }
}