using System;
using Develop03.Assets;

class Program
{
    static void Main(string[] args)
    {
        // BibleAPI bible = new BibleAPI("John", 3, 16, 19);
        // Task<string> getBibleText = bible.FetchVersesAsync();
        // Console.WriteLine(getBibleText.Result);

        Reference refOne = new Reference("John", 3, 16, 19);
        // string text = refOne.GetDisplayText();

        // Console.WriteLine();
        // Console.WriteLine(text);

        Scripture script = new Scripture(refOne);

    }
}


