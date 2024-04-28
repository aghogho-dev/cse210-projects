using System;
using Learning04.Assets;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        Assignment assignOne = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignOne.GetSummary());
        Console.WriteLine();

        MathAssignment mathOne = new MathAssignment("Roberto Rodrigues", "Fractions", "Section 7.3", "Problems 8-19");
        Console.WriteLine(mathOne.GetSummary());
        Console.WriteLine(mathOne.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment writeOne = new WritingAssignment("Mary Waters", "European History", "The Cause of Word War II");
        Console.WriteLine(writeOne.GetSummary());
        Console.WriteLine(writeOne.GetWritingInformation());
        Console.WriteLine();
        
    }
}