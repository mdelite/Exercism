using System;

public enum Schedule
{
    Teenth = 12,
    First = 0,
    Second = 7,
    Third = 14,
    Fourth = 21,
    Last = 31
}

public class Meetup
{
    private DateTime _firstOfMonth;

    public Meetup(int month, int year) => _firstOfMonth = new DateTime(year, month, 1);

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var startDay = schedule == Schedule.Last ? _firstOfMonth.AddMonths(1).AddDays(-8).Day : (int)schedule;
        var addDays = startDay + WeekdayDifference(dayOfWeek, _firstOfMonth.AddDays(startDay).DayOfWeek);
        return _firstOfMonth.AddDays(addDays);
    }

    private int WeekdayDifference(DayOfWeek a, DayOfWeek b)
    {
        var diff = a - b;
        return diff < 0 ? diff +=7 : diff;
    }
}