using System;
using Foundation4.Assets;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Activity running = new Running("Running", 30.0, "03 November 2022", 3.0);

        Activity cycling = new Cycling("Cycling", 30.0, "04 November 2022", 3.0);

        Activity swimming = new Swimming("Swimming", 30.0, "05 November 2022", 96.774);

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        activities.ForEach(p => Console.WriteLine(p.GetSummary()));
    }
}