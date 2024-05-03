using System;
using System.Globalization;
using Learning05.Assets;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("purple", 2.0);
        Rectangle rect = new Rectangle("blue", 2.0, 3.0);
        Circle circle = new Circle("green", 2.0);
        

        List<Shape> shapes = new List<Shape>() {square, rect, circle};

        foreach (Shape shape in shapes)
        {
             Console.WriteLine($"{shape.GetType().Name} color: {shape.GetColor()}");
            Console.WriteLine($"{shape.GetType().Name}: {shape.GetArea()}");

        }
    }
}