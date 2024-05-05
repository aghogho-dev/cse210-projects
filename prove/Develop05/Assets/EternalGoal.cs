using System;

namespace Develop05.Assets;

public class EternalGoal : Goal 
{
    private bool _isComplete;
    private int _timesDone = 0;
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _timesDone += 1;
    }

    public int GetTimesDone()
    {
        return _timesDone;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

}