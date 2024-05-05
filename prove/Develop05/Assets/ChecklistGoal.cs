using System;

namespace Develop05.Assets;

public class ChecklistGoal : Goal 
{
    private int _target;
    private int _bonus;
    private bool _isComplete;
    private int _timesDone = 0;
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _isComplete = false;
        
    }

    public override void RecordEvent()
    {
        if (_timesDone < _target) _timesDone += 1;

        else if (_timesDone == _target) _isComplete = true;
    }

    public int GetTarget()
    {
        return _target;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"[X] {GetShortName()} ({GetDescription()})";
        }
        return $"{base.GetDetailsString()} -- Currently completed: {_timesDone}/{_target}";
    }
}