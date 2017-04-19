using System;
using System.Threading;
using System.Threading.Tasks;

class Tasks
{
    static void Main()
    {
        Task t = Task.Run(() =>
        {
            for (int x = 0; x < 50; x++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        });

        t.Wait();

        // Task that returns value
        Task<int> t2 = Task.Run(() =>
        {
            Thread.Sleep(500);
            return 32;
        });

        Console.WriteLine(t2.Result);

        // Task with continuation
        Task<string> t3 = Task.Run(() =>
        {
            return 50;
        }).ContinueWith((x) =>
        {
            return new String('*', x.Result);
        });

        Console.WriteLine(t3.Result);
    }
}
