using System;
using Learning03.Assets;

class Program
{
    static void Main(string[] args)
    {
        Fraction fOne = new Fraction();
        Console.WriteLine(fOne.GetFractionString());
        Console.WriteLine(fOne.GetDecimalValue());

        Fraction fTwo = new Fraction(5);
        Console.WriteLine(fTwo.GetFractionString());
        Console.WriteLine(fTwo.GetDecimalValue());

        Fraction fThree = new Fraction(3, 4);
        Console.WriteLine(fThree.GetFractionString());
        Console.WriteLine(fThree.GetDecimalValue());

        Fraction fFour = new Fraction(1, 3);
        Console.WriteLine(fFour.GetFractionString());
        Console.WriteLine(fFour.GetDecimalValue());


        Console.WriteLine("\nTesting Getters and Setters");
        Fraction fFive = new Fraction(2, 9);
        Console.WriteLine($"GetTop: {fFive.GetTop()}, GetBottom: {fFive.GetBottom()}");
        Console.WriteLine(fFive.GetFractionString());
        Console.WriteLine(fFive.GetDecimalValue());


        Console.WriteLine("Set top top=3 and bottom=11");
        fFive.SetTop(3);
        fFive.SetBottom(11);
        Console.WriteLine($"GetTop: {fFive.GetTop()}, GetBottom: {fFive.GetBottom()}");
        Console.WriteLine(fFive.GetFractionString());
        Console.WriteLine(fFive.GetDecimalValue());
    }
}