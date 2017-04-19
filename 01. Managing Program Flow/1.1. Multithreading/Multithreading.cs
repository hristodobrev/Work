using System;
using System.Threading;

class Multithreading
{
    public static void ThreadMethod()
    {
        var rnd = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("ThreadProc: {0}", i);
            Thread.Sleep(rnd.Next(101));
        }
        Console.WriteLine("ThreadProc ended its work.");
    }

    public static void ParameterizedThreadMethod(object o)
    {
        var unit = new { type = "", value = 0 };
        unit = Cast(unit, o);
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("{0} -> {1}", unit.type, unit.value * i);
            Thread.Sleep(10);
        }
    }

    private static T Cast<T>(T typeHolder, Object x) // Anonymous Type Casting
    {
        return (T)x;
    }

    public static void Main()
    {
        Thread t = new Thread(new ThreadStart(ThreadMethod));
        t.IsBackground = true;
        t.Start();

        var ts = new ThreadStart(AsyncMethod);
        Thread t2 = new Thread(ts);
        t2.IsBackground = true;
        t2.Start();

        var pts = new ParameterizedThreadStart(ParameterizedThreadMethod);
        Thread t3 = new Thread(pts);
        t3.IsBackground = false;
        t3.Start(new { type = "Worker", value = 5 });
        var a = new { a = 5 };

        t.Join();
        t2.Join();
    }

    public static void AsyncMethod()
    {
        var rnd = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Async Worker: {0}", i);
            Thread.Sleep(rnd.Next(101));
        }
        Console.WriteLine("Async Worker ended its work.");
    }
}