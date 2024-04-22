using System;
using Develop03.Assets;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("What is the name of the Book in the Bible? [For John 3:16, the Book is `John`] ");
        string book = Console.ReadLine();
        Console.Write("What is the name of the Chapter? [For John 3:16, the Chapter is `3`] ");
        int chapter = int.Parse(Console.ReadLine());
        Console.Write("What is the name of the FromVerse? [For John 3:16-19, the Chapter is `16`] ");
        int fromVerse = int.Parse(Console.ReadLine());
        Console.Write("What is the name of the ToVerse (Press Enter if no ToVerse)? [For John 3:16-19, the Chapter is `19`] ");
        string ToVerseString = Console.ReadLine();
        int ToVerseInt = (int.TryParse(ToVerseString, out int _)) ?  int.Parse(ToVerseString) : -99;
        
        Reference refOne = (ToVerseInt != -99) ? new Reference(book, chapter, fromVerse, ToVerseInt) : new Reference(book, chapter, fromVerse);
        Scripture script = new Scripture(refOne);

        string continuePlay;

        Console.Clear();

        while (!script.IsCompletelyHidden())
        {
            Console.WriteLine();

            string toDisplay = $"\n{book} {chapter}:{fromVerse}";

            if (ToVerseInt != -99) toDisplay += $"-{ToVerseInt}";
            
            Console.WriteLine($"{toDisplay} {script.GetDisplayText()}");

            Console.Write("\nPress enter to continue or type quit to finish:\n");

            continuePlay = Console.ReadLine();

            if (continuePlay == "")
            {
                Console.Write("How many words do you want to hide [press enter to use the default value of 3]? ");

                string numberToHideString = Console.ReadLine();


                int numberToHide = (int.TryParse(numberToHideString, out _)) ? int.Parse(numberToHideString) : 3;

                script.HideRandomWords(numberToHide);

                Console.Clear();
            }
            else if (continuePlay == "quit") break;
        }
        
    }
}


