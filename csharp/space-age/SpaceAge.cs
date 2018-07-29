using System;

public class SpaceAge
{
    private long _age;  // age in seconds

    private const long earthPeriod = 31557600; // earth period in seconds
    public SpaceAge(long seconds)
    {
        _age = seconds;
    }

    private double GetYears(double multiplier)
    {
        return _age / (earthPeriod * multiplier);
    }

    public double OnEarth()
    {
        var multiplier = 1.0;
        return GetYears(multiplier);
    }

    public double OnMercury()
    {
        var multiplier = 0.2408467;
        return GetYears(multiplier);
    }

    public double OnVenus()
    {
        var multiplier = 0.61519726;
        return GetYears(multiplier);
    }

    public double OnMars()
    {
        var multiplier = 1.8808158;
        return GetYears(multiplier);
    }

    public double OnJupiter()
    {
        var multiplier = 11.862615;
        return GetYears(multiplier);
    }

    public double OnSaturn()
    {
        var multiplier = 29.447498;
        return GetYears(multiplier);
    }

    public double OnUranus()
    {
        var multiplier = 84.016846;
        return GetYears(multiplier);
    }

    public double OnNeptune()
    {
        var multiplier = 164.79132;
        return GetYears(multiplier);
    }
}