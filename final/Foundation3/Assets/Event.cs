using System;

namespace Foundation3.Assets;

public abstract class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private string _address;
    private string _eventType;

    public Event(string title, string description, string date, string time, string address, string eventType)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
        _eventType = eventType;
    }

    public string StandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nAddress: {_address}\n";
    }

    public abstract string FullDetails();

    public string ShortDescription()
    {
        return $"Type of Event: {_eventType}\nTitle: {_title}\nDate: {_date}";
    }

    public string GetEventType()
    {
        return _eventType;
    }
    
}