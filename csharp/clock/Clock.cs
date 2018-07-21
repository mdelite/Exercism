using System;

public struct Clock
{
    private int _hours;
    private int _minutes;
    public Clock(int hours, int minutes)
    {
        var addHours = 0;

        while(minutes < 0)
        {
            minutes += 60;
            hours -= 1;
        }

        addHours += minutes / 60;
        _hours = Fix(hours + addHours, 24);
        _minutes = Fix(minutes, 60); 
    }

    private static int Fix(int time, int v)
    {
        var remainder = Math.Abs(time % v);
        return time < 0 ? v - remainder : remainder;
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

        while(_minutes < 0)
        {
            _minutes += 60;
            _hours -= 1;
        }

        while(_hours < 0)
        {
            _hours += 24;
        }

        _hours = Fix(_hours + (_minutes / 60), 24);
        _minutes = Fix(_minutes, 60);
        
        return this;        
    }

    public Clock Subtract(int minutesToSubtract) => this.Add(-minutesToSubtract);

    public override string ToString()
    {
        return $"{_hours.ToString("D2")}:{_minutes.ToString("D2")}";
    }
}