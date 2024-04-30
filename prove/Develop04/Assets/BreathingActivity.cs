using System;

namespace Develop04.Assets;

public class BreathingActivity : Activity
{
    public BreathingActivity(): base()
    {

    }

    public void Run()
    {
        SetName("Breathing");
        SetDescription("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing");
        
        Console.WriteLine($"Welcome to the {GetName()} Activity.\n");
        DisplayStartingMessage();
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        int sessionTime = int.Parse(Console.ReadLine());

        SetDuration(sessionTime);

        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(sessionTime);

        while (DateTime.Now < endTime) 
        {
            Console.Write("Breathe in...");
            ShowCountDown(4);

            Console.Write("Now breathe out...");
            ShowCountDown(4);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

}