using System;

public class ProgressGoal : Goal
{
    private double _currentProgress;
    private double _goalTarget;

    public ProgressGoal(string name, string description, int points, double goalTarget, double currentProgress = 0)
        : base(name, description, points)
    {
        _currentProgress = currentProgress;
        _goalTarget = goalTarget;
    }

    public override int RecordEvent()
    {
        _currentProgress++;
        int pointsEarned = _points;

        if (IsComplete())
        {
            pointsEarned = _points * 2; // Double bonus for full completion
        }

        return pointsEarned;
    }

    public override bool IsComplete()
    {
        return _currentProgress >= _goalTarget;
    }

    public override string GetDetailsString()
    {
        double percentComplete = (_currentProgress / _goalTarget) * 100;
        return $"{(IsComplete() ? "[X]" : "[ ]")} {_name} ({_description}) -- {_currentProgress}/{_goalTarget} ({percentComplete:F1}%)";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal,{_name},{_description},{_points},{_goalTarget},{_currentProgress}";
    }
}