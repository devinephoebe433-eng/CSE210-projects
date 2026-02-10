public class BadHabitGoal : Goal
{
    private int _penalty;

    public BadHabitGoal(string name, string description, int penalty)
        : base(name, description, -penalty)
    {
        _penalty = penalty;
    }

    public override int RecordEvent()
    {
        return -_penalty; // Return negative points
    }

    public override bool IsComplete()
    {
        return false; // Bad habits are never complete
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_name} ({_description}) -- Penalty: -{_penalty} points";
    }

    public override string GetStringRepresentation()
    {
        return $"BadHabitGoal,{_name},{_description},{_penalty}";
    }
}