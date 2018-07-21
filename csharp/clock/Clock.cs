using System;

public struct Clock
{
    private int _minutes;

    private const int minutesPerDay = 24 * 60;
    public Clock(int hours, int minutes)
    {
        _minutes = hours * 60 + minutes;
        this.TimeFix();
    }

    private void TimeFix()
    {
        while(_minutes < 0 ) _minutes += minutesPerDay;
        while(_minutes >= minutesPerDay) _minutes -= minutesPerDay;
    }

    public int Hours
    {
        get
        {
            return _minutes / 60;
        }
    }

    public int Minutes
    {
        get
        {
            return _minutes % 60;
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