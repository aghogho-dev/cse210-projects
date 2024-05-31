using System;

namespace Foundation4.Assets;

public class Cycling : Activity
{
    public Cycling(string name, double lengthActivity, string date) : base(name, lengthActivity, date)
    {

    }

    public Cycling(string name, double lengthActivity, string date, double distance) : base(name, lengthActivity, date, distance)
    {
    
    }
}