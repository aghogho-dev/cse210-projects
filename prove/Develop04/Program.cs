using Develop04.Assets;

class Program
{
    static void Main(string[] args)
    {
        int choice = menu();

        if (choice == 1)
        {
            BreathingActivity breathe = new BreathingActivity();
            breathe.Run();
        }
        
    }

    static public int menu()
    {
        Console.WriteLine("New Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");
        Console.Write("\nSelect a choice from the menu: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Clear();

        return choice;
    }
}