using System;
using System.Threading;

class Program
{
    [ThreadStatic] // All threads have their own local field
    public static int field;

    public static void Main()
    {
        new Thread(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                field += 2;
                Console.WriteLine("Thread A: {0}", field);
                Thread.Sleep(20); // Randomize Threads
            }
        }).Start();

        new Thread(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                field++;
                Console.WriteLine("Thread B: {0}", field);
                Thread.Sleep(20); // Randomize Threads
            }
        }).Start();

        Console.ReadKey();
    }
}
