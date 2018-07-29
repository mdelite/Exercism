using System;

public class SpaceAge
{
    private long _age;  // age in seconds

    private const double earth = 1.0;
    private const double mercury = 0.2408467;
    private const double venus = 0.61519726;
    private const double mars = 1.8808158;
    private const double jupiter = 11.862615;
    private const double saturn = 29.447498;
    private const double uranus = 84.016846;
    private const double neptune = 164.79132;

    private const long earthPeriod = 31557600; // earth period in seconds
    public SpaceAge(long seconds)
    {
        _age = seconds;
    }

    private double GetYears(double planet)
    {
        return _age / (earthPeriod * planet);
    }

    public double OnEarth() => GetYears(earth);

    public double OnMercury() => GetYears(mercury);

    public double OnVenus() => GetYears(venus);

    public double OnMars() => GetYears(mars);

    public double OnJupiter() => GetYears(jupiter);

    public double OnSaturn() => GetYears(saturn);

    public double OnUranus() => GetYears(uranus);

    public double OnNeptune() => GetYears(neptune);
}