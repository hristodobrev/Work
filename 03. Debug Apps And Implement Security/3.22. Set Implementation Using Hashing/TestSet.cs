using System;

class TestSet
{
    static void Main()
    {
        Console.WriteLine("Hash set implementation test.");
        Console.WriteLine("Inserting 200 000 items...");
        Set<int> set = new Set<int>();
        var startTime = Environment.TickCount;
        for (int i = 0; i < 200000; i++)
        {
            set.Insert(i);
        }
        var endTime = Environment.TickCount;
        Console.WriteLine("Inserting Time: {0} milliseconds.", (endTime - startTime));


        var randomItem = new Random().Next(400000);

        Console.WriteLine("Iterating 100 000 loops with Contains method.");
        startTime = Environment.TickCount;
        for (int i = 0; i < 100000; i++)
        {
            set.Contains(randomItem);
        }
        endTime = Environment.TickCount;
        Console.WriteLine("Check item Time: {0} milliseconds.", (endTime - startTime));

        long a = 5124564643;
        Console.WriteLine(a.GetHashCode());

        a = 829597346;
        Console.WriteLine(a.GetHashCode());

        a = 5;
        Console.WriteLine(a.GetHashCode());
    }
}