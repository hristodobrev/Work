using System;
using System.Diagnostics;
using System.Threading;

class ReadingData
{
    static void Main()
    {
        Console.WriteLine("Press Escape to stop");
        using (PerformanceCounter pc = new PerformanceCounter("Memory", "Available Bytes"))
        {
            string text = "Available memory: ";
            Console.WriteLine(text);
            do
            {
                while (!Console.KeyAvailable)
                {
                    Console.Write(pc.RawValue);
                    Console.SetCursorPosition(text.Length, Console.CursorTop);
                    Thread.Sleep(1000);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}