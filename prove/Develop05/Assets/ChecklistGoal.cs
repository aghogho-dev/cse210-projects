using System;
using System.ComponentModel;

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
        base.SetGoalName("ChecklistGoal");
    }

    public override void RecordEvent()
    {
        if (_timesDone < _target) _timesDone += 1;

        if (_timesDone == _target) _isComplete = true;
    }

    public int GetTarget()
    {
        return _target;
    }

    public void SetTarget(int target)
    {
        _target = target;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public void SetBonus(int bonus)
    {
        _bonus = bonus;
    }

    public int GetTimesDone()
    {
        return _timesDone;
    }

    public void SetTimesDone(int timesDone)
    {
        _timesDone = timesDone;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"[X] {GetShortName()} ({GetDescription()}) -- Currently completed: {_timesDone}/{_target}";
        }
        return $"{base.GetDetailsString()} -- Currently completed: {_timesDone}/{_target}";
    }

    public override int UpdateScore()
    {
        if (IsComplete())
        {
            return _bonus + base.UpdateScore();
        }

        return base.UpdateScore();
    }

    public void SetIsComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }

}