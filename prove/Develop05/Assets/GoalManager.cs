using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks.Dataflow;

namespace Develop05.Assets;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private List<Goal> _notCompleted; 

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _notCompleted = new List<Goal>();
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();

            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            List<int> optionsNumber = new List<int>() {1, 2, 3, 4, 5, 6};
            
            Console.Write("Selet a choice from the menu: ");
            string choice = Console.ReadLine().Trim();
            bool choiceBool = int.TryParse(choice, out _);
        

            while (!choiceBool || !optionsNumber.Contains(int.Parse(choice))) 
            {
                Console.WriteLine("\nYour choice is not in the options.\n");

                Console.Write("Selet a choice from the menu: ");
                choice = Console.ReadLine().Trim();
                choiceBool = int.TryParse(choice, out _);
            }

            Console.Clear();

            int choiceInt = int.Parse(choice);

            if (choiceInt == 1)
            {
                Goal goal = CreateGoal(); 
                _goals.Add(goal);
            }
            else if (choiceInt == 2)
            {
                if (_goals.Count > 0) ListGoalDetails();
                else Console.WriteLine("You do not have any goals.");

                Console.WriteLine("\nPress Enter button to continue");
                Console.ReadLine();
            }
            else if (choiceInt == 3)
            {
                SaveGoals();
            }
            else if (choiceInt == 4)
            {
                LoadGoals();
            } 
            else if (choiceInt == 5)
            {
                RecordEvent();

            }
            else if (choiceInt == 6)
            {
                break;
            }
        }   
    }

    public void LoadGoals()
    {
        _goals = new List<Goal>();

        string filename = "";

        while (true)
        {
            Console.Write("What is the filename to load goals from? ");
            filename = Console.ReadLine().Trim();

            if (filename != "") break;
        }

        string[] lines = File.ReadAllLines(filename);

        int score = int.Parse(lines[0]);
        _score = score;

        string[] breakLine;
        string goalName;
        string isComplete;
        string shortName;
        string description;
        string points;
        string target = "";
        string bonus = "";
        int timesDone = 0;


        foreach (string line in lines.Skip(1))
        {
            if (line.Contains("ChecklistGoal"))
            {
                breakLine = line.Split(",");
                goalName = breakLine[0];
                isComplete = breakLine[1];
                shortName = breakLine[2];
                description = breakLine[3];
                points = breakLine[4];
                target = breakLine[5];
                bonus = breakLine[6];
                timesDone = int.Parse(breakLine[7]);
            }
            else
            {
                breakLine = line.Split(",");
                goalName = breakLine[0];
                isComplete = breakLine[1];
                shortName = breakLine[2];
                description = breakLine[3];
                points = breakLine[4];
            }

            int pointsInt = int.Parse(points);
            int targetInt = 0;
            int bonusInt = 0;

            if (goalName == "ChecklistGoal")
            {
                targetInt = int.Parse(target);
                bonusInt = int.Parse(bonus);
            }

            Goal returnValue = (goalName == "SimpleGoal") 
                        ? new SimpleGoal(shortName, description, pointsInt) : (goalName == "EternalGoal")
                        ? new EternalGoal(shortName, description, pointsInt): new ChecklistGoal(shortName, description, pointsInt, targetInt, bonusInt);

            

            if (goalName == "SimpleGoal") 
            {
                SimpleGoal simple = (SimpleGoal)returnValue;
                simple.SetIsComplete(Boolean.Parse(isComplete));
                simple.SetGoalName(goalName);
                _goals.Add((Goal)simple);
            }
            else if (goalName == "EternalGoal") 
            {
                EternalGoal eternal = (EternalGoal)returnValue;
                eternal.SetIsComplete(Boolean.Parse(isComplete));
                eternal.SetGoalName(goalName);
                _goals.Add((Goal)eternal);
            }

            else if (goalName == "ChecklistGoal") 
            {
                ChecklistGoal check = (ChecklistGoal)returnValue;
                check.SetIsComplete(Boolean.Parse(isComplete));
                check.SetTarget(targetInt);
                check.SetBonus(bonusInt);
                check.SetGoalName(goalName);
                check.SetTimesDone(timesDone);
                _goals.Add((Goal)check);
            }
        }
    }

    public void SaveGoals()
    {
        string filename = "";
               
        while (true)
        {
            Console.Write("What is the filename to save the goal? ");
            filename = Console.ReadLine().Trim();

            if (filename != "") break;
        }

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score); 

            foreach (Goal goal in _goals)
            {
                string write = goal.GetStringRepresentation();

                outputFile.WriteLine(write);
            }    
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.\n");
    }

    private void ListGoalsNotCompleted()
    {
        _notCompleted = _goals.Where((goal) => goal.IsComplete() == false).ToList();
    }

    public void ListGoalNames()
    {
        
        ListGoalsNotCompleted();

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _notCompleted.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_notCompleted[i].GetShortName()}");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();

        if (_notCompleted.Count > 0)
        {
            Console.Write("Which goal did you accomplish? ");
            string completed = Console.ReadLine();
            bool completedBool = int.TryParse(completed, out _);

            while (!completedBool || int.Parse(completed) > _notCompleted.Count)
            {
                Console.WriteLine("\nYour choice is not in the options.\n");

                Console.Write("Which goal did you accomplish? ");
                completed = Console.ReadLine();
                completedBool = int.TryParse(completed, out _);
            }

            int completedInt = int.Parse(completed);

            int indexGoal = _goals.IndexOf(_notCompleted[completedInt - 1]);

            _goals[indexGoal].RecordEvent();
            _score += _goals[indexGoal].UpdateScore();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("\nYou do not currently have any unaccomplished goals.\n");
            Console.WriteLine("Press Enter to continue ");
            Console.ReadLine();
        }   
    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private Goal CreateGoal()
    {
            Console.WriteLine("The types of Goals are: ");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");

            List<int> goalsNumber = new List<int>() {1, 2, 3};

            Console.Write("Which type of goal would you like to create? ");
            string goalType = Console.ReadLine().Trim();
            bool goalTypeBool = int.TryParse(goalType, out _);

            while (!goalTypeBool || !goalsNumber.Contains(int.Parse(goalType)))
            {
                Console.WriteLine("\nYou choice is not in the options.\n");

                Console.Write("Which type of goal would you like to create? ");
                goalType = Console.ReadLine().Trim();
                goalTypeBool = int.TryParse(goalType, out _);
            }

            int goalTypeInt = int.Parse(goalType);

            Console.Clear();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            bool pointsBool = int.TryParse(points, out _);

            if (!pointsBool)
            {
                Console.WriteLine("\nYou points should be an integer.\n");

                Console.Write("What is the amout of points associated with this goal? ");
                points = Console.ReadLine();
                pointsBool = int.TryParse(points, out _);
            }

            int pointsInt = int.Parse(points);

            int targetInt = 0;
            int bonusInt = 0;

            if (goalTypeInt == 3)
            {
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                string target = Console.ReadLine().Trim();
                bool targetBool = int.TryParse(target, out _);

                while (!targetBool)
                {
                    Console.WriteLine("\nYou target should be an integer.\n");

                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    target = Console.ReadLine().Trim();
                    targetBool = int.TryParse(target, out _);
                }

                targetInt = int.Parse(target);

                Console.Write("What is the bonus for accomplishing it that many times? ");
                string bonus = Console.ReadLine().Trim();
                bool bonusBool = int.TryParse(bonus, out _);

                while (!bonusBool)
                {
                    Console.WriteLine("\nYou bonus should be an integer.\n");

                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    bonus = Console.ReadLine().Trim();
                    bonusBool = int.TryParse(bonus, out _);
                }

                bonusInt = int.Parse(bonus);   
            }

            Goal returnValue = (goalTypeInt == 1) 
                        ? new SimpleGoal(name, description, pointsInt) : (goalTypeInt == 2)
                        ? new EternalGoal(name, description, pointsInt): new ChecklistGoal(name, description, pointsInt, targetInt, bonusInt);

            return returnValue;

    }
}