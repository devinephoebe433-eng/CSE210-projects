public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false; // Never complete
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_name} ({_description}) -- (Eternal, repeats forever)";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal,{_name},{_description},{_points}";
    }
}