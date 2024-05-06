using System;

namespace Develop05.Assets;

public class Goal
{
    private string _shortName;
    private string _description;
    private int _points;
    private string _goalName;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _goalName = "";
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public virtual int UpdateScore()
    {
        return GetPoints();
    }

    public virtual void RecordEvent()
    {

    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetDetailsString()
    {
        return $"[] {_shortName} ({_description})";
    }

    public virtual string GetStringRepresentation()
    {
        return "";
    }

    public string GetGoalName()
    {
        return _goalName;
    }

    public void SetGoalName(string goalName)
    {
        _goalName = goalName;
    }

}