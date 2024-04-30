using System;

namespace Develop04.Assets;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();
    private List<int> _usedPromptIndex = new List<int>();
    private List<string> _userList = new List<string>();

    public ListingActivity() : base()
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");

        _count = 0;
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();

        int index;

        while (true)
        {
            if (_prompts.Count == _usedPromptIndex.Count) _usedPromptIndex = new List<int>();

            index = random.Next(_prompts.Count);

            if (!_usedPromptIndex.Contains(index))
            {
                _usedPromptIndex.Add(index);
                break;
            }
        }        
        return _prompts[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"--- {_prompts[_usedPromptIndex.Last()]} ---");
    }

    public List<string> GetListFromUser()
    {
        Console.Write("> ");
        string userString = Console.ReadLine();
        _userList.Add(userString);

        return _userList;
    }

    public void Run()
    {
        SetName("Listing");
        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

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

        Console.WriteLine("List as many responses you can to the following prompt:");
        GetRandomPrompt();
        DisplayPrompt();

        Console.Write("You may begin in ");
        ShowCountDown(5);


        while (DateTime.Now < endTime)
        {
            GetListFromUser();
            _count += 1;
        }

        Console.WriteLine($"You listed {_count} items!\n");
        DisplayEndingMessage();

    }

}