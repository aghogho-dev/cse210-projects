using System;

namespace Foundation4.Assets;

public class Running : Activity
{
    public Running(string name, double lengthActivity, string date) : base(name, lengthActivity, date)
    {

    }

    public Running(string name, double lengthActivity, string date, double distance) : base(name, lengthActivity, date, distance)
    {
    
    }
}