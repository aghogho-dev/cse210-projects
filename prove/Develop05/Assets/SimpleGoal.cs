using System;

namespace Develop05.Assets;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
        base.SetGoalName("SimpleGoal");
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public void SetIsComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }

    public override string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"[X] {GetShortName()} ({GetDescription()})";
        }
        return base.GetDetailsString();
    }

    public override string GetStringRepresentation()
    {
        return base.GetStringRepresentation();
    }
}