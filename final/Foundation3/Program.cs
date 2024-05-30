using System;
using Foundation3.Assets;

class Program
{
    static void Main(string[] args)
    {
        string lectureTitle = "Programming with Classes";
        string lectureDescr = "You will learn about Abstraction, Encapsulation, Inheritance, and Polymorphism";
        string lectureDate = "June 10, 2024";
        string lectureTime = "10:00 A.M.";
        string lectureAddress = "Main Auditorium, University of Kiva";
        string lectureEventType = "Lecture";
        string lectureSpeaker = "Dave Mann";
        int lectureCapacity = 200;

        Lecture lecture = new Lecture(
            lectureTitle, lectureDescr, lectureDate, 
            lectureTime, lectureAddress, lectureEventType,
            lectureSpeaker, lectureCapacity
        );


        string receptionTitle = "Blaze After Party";
        string receptionDescr = "Reception and After Party for the Blaze Award Ceremony";
        string receptionDate = "August 12, 2024";
        string receptionTime = "4:00 P.M.";
        string receptionAddress = "KM 2, BXY, Avenue Cresent";
        string receptionEventType = "Reception";
        string receptionName = "Ben";
        string receptionEmail = "ben@blaze.org";
        int receptionCapacity = 500;

        Reception reception = new Reception(
            receptionTitle, receptionDescr, receptionDate, 
            receptionTime, receptionAddress, receptionEventType,
            receptionName, receptionEmail, receptionCapacity
        );


        string outdoorTitle = "Football Game";
        string outdoorDescr = "Sunday League Football between Elves and Oldham";
        string outdoorDate = "June 10, 2024";
        string outdoorTime = "10:00 A.M.";
        string outdoorAddress = "Main Auditorium, University of Kiva";
        string outdoorEventType = "Outdoor";
        string outdoorWeather = "Sunny";

        Outdoor outdoor = new Outdoor(
            outdoorTitle, outdoorDescr, outdoorDate, 
            outdoorTime, outdoorAddress, outdoorEventType, outdoorWeather
        );

        Console.WriteLine();

        Console.WriteLine(lecture.StandardDetails());
        Console.WriteLine(lecture.FullDetails());
        Console.WriteLine(lecture.ShortDescription());

        Console.WriteLine("-----------------------------------------\n");

        Console.WriteLine(reception.StandardDetails());
        Console.WriteLine(reception.FullDetails());
        Console.WriteLine(reception.ShortDescription());

         Console.WriteLine("-----------------------------------------\n");

        Console.WriteLine(outdoor.StandardDetails());
        Console.WriteLine(outdoor.FullDetails());
        Console.WriteLine(outdoor.ShortDescription());

        Console.WriteLine();



    }
}