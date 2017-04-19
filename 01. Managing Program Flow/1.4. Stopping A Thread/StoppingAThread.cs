using System;
using System.Threading;

class StoppingAThread
{
    private static bool stopped = false;

    static void Main()
    {
        Thread t = new Thread(new ThreadStart(ThreadMethod));
        t.IsBackground = true;
        t.Start();

        // Thread.Sleep(200);
        // t.Abort();

        try
        {
            // Thread.CurrentThread.Abort();
        }
        catch (ThreadAbortException ex)
        {
            Console.WriteLine(ex);
        }

        // bool stopped = false;
        Thread t2 = new Thread(new ThreadStart(() =>
        {
            Console.WriteLine(stopped);
            while (!stopped)
            {
                Console.WriteLine("Running Anonymous Thread... ({0:HH:mm:ss})", DateTime.Now);
                Thread.Sleep(1000);
            }
        }));

        Thread t3 = new Thread(new ThreadStart(TestThreadMethod));

        t2.Start();
        t3.Start();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        stopped = true;

        // t2.Join();
        t.Join();
    }

    static void TestThreadMethod()
    {
        Console.WriteLine(stopped);
        while (!stopped)
        {
            Console.WriteLine("Running Normal Thread... ({0:HH:mm:ss})", DateTime.Now);
            Thread.Sleep(1000);
        }
    }

    static void ThreadMethod(object o)
    {
        for (int i = 0; i < (int)o; i++)
        {
            Console.WriteLine("ThreadProc: {0}", i);
            Thread.Sleep(0);
        }
    }

    static void ThreadMethod()
    {
        try
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 6)
                {
                    // Abort current thread if i = 6
                    // Thread.CurrentThread.Abort();
                }

                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(50);
            }
        }

        catch (ThreadAbortException ex)
        {
            Console.WriteLine("Waiting for last...");
            Console.WriteLine(ex);
            Thread.Sleep(1000);
        }
    }
}