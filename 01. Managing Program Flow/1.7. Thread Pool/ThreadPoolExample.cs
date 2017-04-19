using System;
using System.Threading;

class ThreadPoolExample
{
    static void Main()
    {
        ThreadPool.QueueUserWorkItem((s) =>
        {
            Console.WriteLine("Working on a thread from threadpool.");
        });

        Thread.Sleep(1);

        Console.WriteLine("Main thread exits.");
    }
}