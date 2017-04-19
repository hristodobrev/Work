using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class CreatingADeadlock
{
    static void Main()
    {
        int nTasks = 0;
        object o = nTasks;
        List<Task> tasks = new List<Task>();

        try
        {
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    Thread.Sleep(250);
                    Monitor.Enter(o);
                    try
                    {
                        nTasks++;
                    }
                    finally
                    {
                        Monitor.Exit(o);
                    }
                }));
            }
            
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("{0} tasks started and executed.", nTasks);
        }
        catch (AggregateException ex)
        {
            String msg = String.Empty;
            foreach (var ie in ex.InnerExceptions)
            {
                Console.WriteLine("{0}", ie.GetType().Name);
                if (!msg.Contains(ie.Message))
                {
                    msg += ie.Message + Environment.NewLine;
                }

                Console.WriteLine("\nException Message(s):");
                Console.WriteLine(msg);
            }
        }


        return;

        object lockA = new object();
        object lockB = new object();

        var up = Task.Run(() =>
        {
            lock (lockA)
            {
                Thread.Sleep(1000);
                lock (lockB)
                {
                    Console.WriteLine("Locked A and B");
                }
            }
        });

        Thread.Sleep(10);
        lock (lockB) // Beacause of the inversed order of the locks taken here occurs a deadlock
        {
            lock (lockA)
            {
                Console.WriteLine("Locked B and A");
            }
        }

        up.Wait();
    }
}
