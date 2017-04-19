using System;

class TestSet
{
    static void Main()
    {
        Console.WriteLine("Naive set implementation test.");
        Console.WriteLine("Inserting 20 000 items...");
        Set<int> set = new Set<int>();
        var startTime = Environment.TickCount;
        for (int i = 0; i < 20000; i++)
        {
            set.Insert(i);
        }
        var endTime = Environment.TickCount;
        Console.WriteLine("Inserting Time: {0} milliseconds.", (endTime - startTime));


        var randomItem = new Random().Next(40000);

        Console.WriteLine("Iterating 10 000 loops with Contains method.");
        startTime = Environment.TickCount;
        for (int i = 0; i < 10000; i++)
        {
            set.Contains(randomItem);
        }
        endTime = Environment.TickCount;
        Console.WriteLine("Check item Time: {0} milliseconds.", (endTime - startTime));
    }
}