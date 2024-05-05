using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Develop05.Assets;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine($"You have {_score} points.\n");

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
                Goal goal = GoalsType(); 
                _goals.Add(goal);
            }
            else if (choiceInt == 2)
            {
                ListGoalDetails();

                Console.WriteLine("\nPress Enter button to continue");
                Console.ReadLine();
            }
            else if (choiceInt == 3)
            {

            }
            else if (choiceInt == 4)
            {

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

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        string completed = Console.ReadLine();
        bool completedBool = int.TryParse(completed, out _);

        while (!completedBool || int.Parse(completed) > _goals.Count)
        {
            Console.WriteLine("\nYour choice is not in the options.\n");

            Console.Write("Which goal did you accomplish? ");
            completed = Console.ReadLine();
            completedBool = int.TryParse(completed, out _);
        }

        int completedInt = int.Parse(completed);

        _goals[completedInt - 1].RecordEvent();

    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private Goal GoalsType()
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