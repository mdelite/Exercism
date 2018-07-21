using System;

public struct Clock
{
    private int _hours;
    private int _minutes;
    public Clock(int hours, int minutes)
    {
        _hours = hours;
        _minutes = minutes;

        this.TimeFix();
    }

    private void TimeFix()
    {
        var addHours = 0;

        while(_minutes < 0)
        {
            _minutes += 60;
            _hours -= 1;
        }

        addHours += _minutes / 60;
        _hours = Fix(_hours + addHours, 24);
        _minutes = Fix(_minutes, 60); 
    }

    private static int Fix(int time, int v)
    {
        var remainder = Math.Abs(time % v);
        
        return time < 0 && remainder != 0 ? v - remainder : remainder;
    }

    public int Hours
    {
        get
        {
            return _hours;
        }
    }

    public int Minutes
    {
        get
        {
            return _minutes;
        }
    }

    public Clock Add(int minutesToAdd)
    {
        _minutes += minutesToAdd;
        this.TimeFix();
        
        return this;        
    }

    public Clock Subtract(int minutesToSubtract) => this.Add(-minutesToSubtract);

    public override string ToString()
    {
        return $"{this.Hours.ToString("D2")}:{this.Minutes.ToString("D2")}";
    }
}