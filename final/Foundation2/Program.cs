using System;
using Foundation2.Assets;

class Program
{
    static void Main(string[] args)
    {
        Address addressOne = new Address("10 XYZ Avenue", "Queens", "New York", "USA");
        Customer customerOne = new Customer("Ben Davis", addressOne);
        Order orderOne = new Order(customerOne);

        Product productOne = new Product("Book", 100, 32.5, 5);
        Product productTwo = new Product("Bag", 255, 12.0, 1);

        orderOne.OrderProduct(productOne);
        orderOne.OrderProduct(productTwo);


        Address addressTwo = new Address("10 ABC Cresent", "Warri", "Delta", "Nigeria");
        Customer customerTwo = new Customer("Chapman White", addressTwo);
        Order orderTwo = new Order(customerTwo);

        Product productThree = new Product("Game", 12, 200.0, 500);
        Product productFour= new Product("Shoe", 15, 49.99, 10);
        Product productFive= new Product("Laptop", 11, 1599.0, 6);

        orderTwo.OrderProduct(productThree);
        orderTwo.OrderProduct(productFour);
        orderTwo.OrderProduct(productFive);

        Console.WriteLine($"\nPacking Label:{orderOne.PackingLabel()}");
        Console.WriteLine($"\nShipping Label:{orderOne.ShippingLabel()}");
        Console.WriteLine($"\nTotal Price: {orderOne.TotalPrice()}\n");


        Console.WriteLine($"\nPacking Label:{orderTwo.PackingLabel()}");
        Console.WriteLine($"\nShipping Label:{orderTwo.ShippingLabel()}");
        Console.WriteLine($"\nTotal Price: {orderTwo.TotalPrice()}\n");
    }
}