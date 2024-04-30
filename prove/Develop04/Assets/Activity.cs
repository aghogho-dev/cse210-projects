using System;
using System.Runtime.CompilerServices;

namespace Develop04.Assets;

public class Activity
{
    private string _name = "";
    private string _description = "";
    private int _duration = 0;

    public Activity()
    {

    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine(_description);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        ShowSpinner(5);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(5);
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string>();

        spinner.Add("|");
        spinner.Add("/");
        spinner.Add("—");
        spinner.Add("\\");
        spinner.Add("|");
        spinner.Add("/");
        spinner.Add("—");
        spinner.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = spinner[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i > spinner.Count - 1) i = 0;
        }

        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            if (i < 10)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            else if (i < 100)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b\b  \b\b");
            }
            else if (i < 1000)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b\b\b   \b\b\b");
            }
        }
        Console.WriteLine();
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

}