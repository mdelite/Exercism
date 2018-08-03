using System;

public class Robot
{
    private string _name = "";
    public string Name
    {
        get
        {
            if(_name == "") Reset();
            return _name;
        }
    }

    public void Reset()
    {
        var rnd = new Random();
        var name = "";

        name += (char)rnd.Next(65, 90);
        name += (char)rnd.Next(65, 90);
        name += rnd.Next(0, 999).ToString("D3");

        _name = name;
    }
}