using System;

public class NegativeGoal : Goal
{
    public NegativeGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        return -_points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[!] {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{_points}";
    }
}
