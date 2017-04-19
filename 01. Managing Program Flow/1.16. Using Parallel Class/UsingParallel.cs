using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class UsingParallel
{
    static void Main()
    {
        // ParallelLoopBreaking();
        // TestStringConcatenating();

        // return;

        //for (int i = 0; i < 10; i++)
        //{
        //    Console.WriteLine(i);
        //    Thread.Sleep(1000);
        //}

        Console.WriteLine();


        int a = 0;

        Parallel.For(0, 100, (i) =>
        {
            a++;
            Console.WriteLine(a);
            // Console.WriteLine("{0} from for | a = {1}", i, a);
            Thread.Sleep(1000);
        });

        Console.WriteLine(a);

        var numbers = Enumerable.Range(0, 10);
        Parallel.ForEach(numbers, i =>
        {
            Console.WriteLine("{0} from foreach", i);
            Thread.Sleep(500);
        });


    }

    static void TestStringConcatenating()
    {
        int a = 0;
        string result = "";

        //for (int i = 0; i < 100000; i++)
        //{
        //    a++;
        //    result += a;
        //}

        Parallel.For(0, 100000, i =>
        {
            a++;
            result += a;
        });

        Console.WriteLine(result);
    }

    static void ParallelLoopBreaking()
    {
        int a = 0;
        ulong b = 1;

        ParallelLoopResult result = Parallel
            .For(0, 100, (int i, ParallelLoopState loopState) =>
            {
                a++;
                b *= (ulong)a;
                Console.WriteLine(b);
                if (i == 24)
                    loopState.Break();
            });

        Console.WriteLine(result.LowestBreakIteration);
        Console.WriteLine(result.IsCompleted);
        Console.WriteLine(a);
    }
}