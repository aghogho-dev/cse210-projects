using System;

namespace Foundation3.Assets;

public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, string date, string time, string address, string eventType, string speaker, int capacity) : base(title, description, date, time, address, eventType)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string FullDetails()
    {
        return $"{StandardDetails()}Type of Event: {base.GetEventType()}\nSpeaker: {_speaker}\nCapacity: {_capacity}\n";
    }
}