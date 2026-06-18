using System;

abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public virtual string GetActivityName()
    {
        return "Activity";
    }

    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetActivityName()} ({_minutes} min)- " +
            $"Distance {GetDistance():0.0} miles, " +
            $"Speed {GetSpeed():0.0} mph, " +
            $"Pace: {GetPace():0.0} min per mile";
    }
}
