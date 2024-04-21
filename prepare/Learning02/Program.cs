using System;

class Program
{
    static void Main(string[] args)
    {
        Job engineer = new Job();
        engineer._jobTitle = "Software Engineer";
        engineer._company = "Microsoft";
        engineer._startYear = 2019;
        engineer._endYear = 2022;

        Job manager = new Job();
        manager._jobTitle = "Manager";
        manager._company = "Apple";
        manager._startYear = 2022;
        manager._endYear = 2023;

        Resume sarah = new Resume();
        sarah._name = "Allison Rose";
        sarah._jobs.Add(engineer);
        sarah._jobs.Add(manager);

        sarah.Display();

    }
}

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public Job()
    {

    }

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

public class Resume 
{
    public string _name;
    public List<Job> _jobs;

    public Resume()
    {
        _jobs = new List<Job>();
    }

    public void Display()
    {
        Console.WriteLine($"Name: {_name}\nJobs:");


        foreach (Job job in _jobs) job.Display();
    }
}