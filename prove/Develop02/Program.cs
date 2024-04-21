using System;
using Develop02.Assets;

class Program
{
    static void Main(string[] args)
    {
        Entry newEntry;
        PromptGenerator prompt = new PromptGenerator();
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What do you want to do? ");
            
            string toDo = Console.ReadLine();

            if (toDo == "1")
            {
                
                string getPrompt = prompt.GetRandomPrompt();
                Console.WriteLine(getPrompt);
                string promptResponse = Console.ReadLine();

                newEntry = new Entry();

                newEntry._promptText = getPrompt;
                newEntry._entryText = promptResponse;

                journal.AddEntry(newEntry);
            }
            else if (toDo == "2")
            {
                journal.DisplayAll();
            }
            else if (toDo == "3")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();

                journal.LoadFromFile(fileName);

            }
            else if (toDo == "4")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();

                journal.SaveToFile(fileName);
            }
            else if (toDo == "5") 
            {
                break;
            }
        }
    }
}