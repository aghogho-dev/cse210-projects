using System;

namespace Foundation4.Assets;

public abstract class Activity
{
    private double _distance = 0;
    private double _lengthActivity;

    private string _date;
    private string _name;

    public Activity(string name, double lengthActivity, string date)
    {
        _lengthActivity = lengthActivity;
        _date = date;
        _name = name;
    }

    public Activity(string name, double lengthActivity, string date, double distance)
    {
        _lengthActivity = lengthActivity;
        _date = date;
        _distance = distance;
        _name = name;
    }

    public void SetDistance(double distance)
    {
        _distance = distance;
    }

    public double GetMinutes()
    {
        return _lengthActivity;
    }

    public virtual double GetDistance()
    {
        return Math.Round(_distance, 2);
    }

    public virtual double GetSpeed()
    {
        return Math.Round((_distance / _lengthActivity) * 60, 2);
    }

    public virtual double GetPace()
    {
        return Math.Round(60 / GetSpeed(), 2);
    }

    public string GetSummary()
    {
        return $"{_date} {_name} ({_lengthActivity} min) - Distance {Math.Round(GetDistance(), 1)} miles, Speed {Math.Round(GetSpeed(), 1)} mph, Pace {Math.Round(GetPace(), 1)} min per mile";
    }

}