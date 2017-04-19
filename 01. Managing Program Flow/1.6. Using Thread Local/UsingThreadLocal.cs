using System;
using System.Threading;

class UsingThreadLocal
{
    public static ThreadLocal<int> field = new ThreadLocal<int>(() =>
    {
        // return 10;
        return Thread.CurrentThread.ManagedThreadId;
    });

    static void Main()
    {
        new Thread(() =>
        {
            for (int i = 0; i < field.Value; i++)
            {
                Console.WriteLine("Thread A: {0}", i);
            }
        }).Start();

        new Thread(() =>
        {
            for (int i = 0; i < field.Value; i++)
            {
                Console.WriteLine("Thread B: {0}", i);
            }
        }).Start();

        new Thread(() =>
        {
            for (int i = 0; i < field.Value; i++)
            {
                Console.WriteLine("Thread C: {0}", i);
            }
        }).Start();

        new Thread(() =>
        {
            for (int i = 0; i < field.Value; i++)
            {
                Console.WriteLine("Thread D: {0}", i);
            }
        }).Start();
    }
}
