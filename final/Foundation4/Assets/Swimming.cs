using System;

namespace Foundation4.Assets;

public class Swimming : Activity
{
    private double _numberLaps;
    public Swimming(string name, double lengthActivity, string date, double numberLaps) : base(name, lengthActivity, date)
    {
        _numberLaps = numberLaps;
    }

    public override double GetDistance()
    {
        return Math.Round(_numberLaps * 50 / 1000 * 0.62, 1);
    }

    public override double GetPace()
    {
        return Math.Round(base.GetMinutes() / GetDistance(), 1);
    }

    public override double GetSpeed()
    {
        return Math.Round(60 / GetPace(), 1);
    }

}