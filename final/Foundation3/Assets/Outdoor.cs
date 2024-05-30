using System;

namespace Foundation3.Assets;

public class Outdoor : Event
{
    private string _weather;

    public Outdoor(string title, string description, string date, string time, string address, string eventType, string weather) : base(title, description, date, time, address, eventType)
    {
        _weather = weather;
    }

    public override string FullDetails()
    {
        return $"{StandardDetails()}Type of Event: {base.GetEventType()}\nWeather: {_weather}\n";
    }
}