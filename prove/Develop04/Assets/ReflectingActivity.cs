using System;

namespace Develop04.Assets;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<int> _usedPromptIndex = new List<int>();
    private List<string> _questions = new List<string>();
    private List<int> _usedQuestionsIndex = new List<int>();

    public ReflectingActivity() : base()
    {
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was completed?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");

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

    public string GetRandomQuestion()
    {
        Random random = new Random();

        int index;

        while (true)
        {
            if (_questions.Count == _usedQuestionsIndex.Count) _usedQuestionsIndex = new List<int>();

            index = random.Next(_questions.Count);

            if (!_usedQuestionsIndex.Contains(index))
            {
                _usedQuestionsIndex.Add(index);
                break;
            }
        }
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"--- {_prompts[_usedPromptIndex.Last()]} ---");
    }

    public void DisplayQuestion()
    {
        Console.Write($"> {_questions[_usedQuestionsIndex.Last()]} ");
    }

    public void Run()
    {
        SetName("Reflecting");
        SetDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

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

        GetRandomPrompt();
        DisplayPrompt();

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");

        string pressEnter = Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(3);
        Console.Clear();

        while (DateTime.Now < endTime)
        {  
            GetRandomQuestion();
            DisplayQuestion();
            ShowSpinner(5);
        }
        
        Console.WriteLine();
        DisplayEndingMessage();
    }
}