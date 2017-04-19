using System;
using System.Diagnostics;
using System.Text;

class UsingStopWatchClass
{
    const int numberOfIteration = 100000;

    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Algorithm1();
        sw.Stop();
        Console.WriteLine(sw.Elapsed);

        sw.Reset();
        sw.Start();
        Algorithm2();
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
    }

    static void Algorithm1()
    {
        string result = "";
        for (int i = 0; i < numberOfIteration; i++)
        {
            result += 'a';
        }
    }


    static void Algorithm2()
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < numberOfIteration; i++)
        {
            result.Append('a');
        }
    }
}