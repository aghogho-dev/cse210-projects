using System;

namespace Foundation3.Assets;

public class Reception : Event
{
    private string _name;
    private string _email;
    private int _capacity;

    public Reception(string title, string description, string date, string time, string address, string eventType, string name, string email, int capacity) : base(title, description, date, time, address, eventType)
    {
        _name = name;
        _email = email;
        _capacity = capacity;
    }

    public override string FullDetails()
    {
        return $"{StandardDetails()}Type of Event: {base.GetEventType()}\nCapacity: {_capacity}\nRSVP: {_name} {_email}\n";
    }
}