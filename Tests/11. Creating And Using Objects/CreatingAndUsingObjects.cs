using System;
using System.Collections.Generic;
using Chapter1;

class CreatingAndUsingObjects
{
    static void Main()
    {
        int startTime = Environment.TickCount;
        Cat cat = new Cat("Tina", "Orange");
        cat.SayMeow();

        Console.WriteLine(Sequence.NextValue());
        Console.WriteLine(Sequence.NextValue());
        Console.WriteLine(Sequence.NextValue());
        Console.WriteLine(Sequence.NextValue());

        int sum = 0;
        for (int i = 0; i < 10000000; i++)
        {
            sum++;
        }

        int endTime = Environment.TickCount;
        Console.WriteLine("The time elapsed is {0} sec.", (endTime - startTime) / 1000.0);

        var passwordGenerator = new PasswordGenerator();
        Console.WriteLine(passwordGenerator.GetRandomPassword());
        Console.WriteLine(passwordGenerator.GetRandomPassword());

        var passwordGenerator2 = new PasswordGenerator(1, 4, 3, 0, 10);
        Console.WriteLine(passwordGenerator2.GetRandomPassword());
        Console.WriteLine(passwordGenerator2.GetRandomPassword());

        DisplayUpTime();
    }

    static void DisplayUpTime()
    {
        var upTimeInSeconds = Environment.TickCount / 1000;
        var seconds = upTimeInSeconds % 60;
        var minutes = (upTimeInSeconds / 60) % 60;
        var hours = (upTimeInSeconds / 3600) % 24;
        var days = upTimeInSeconds / (3600 * 24);

        // 1 hour -> 60 minutes -> 3600 seconds
        // 1 day -> 24 hours -> 1440 minutes -> 86400 seconds

        Console.WriteLine("Up time: {0}:{1:00}:{2:00}:{3:00}", days, hours, minutes, seconds);
    }
}