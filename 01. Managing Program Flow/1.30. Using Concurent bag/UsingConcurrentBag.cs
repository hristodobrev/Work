using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

class UsingConcurrentBag
{
    static void Main()
    {
        EnumeratingConcurrentBag();
        return;

        ConcurrentBag<int> bag = new ConcurrentBag<int>();

        bag.Add(42);
        bag.Add(21);
        bag.Add(23);
        bag.Add(64);

        int result;
        if (bag.TryTake(out result))
        {
            Console.WriteLine(result);
        }

        if (bag.TryPeek(out result))
        {
            Console.WriteLine("There is a next item: {0}", result);
        }

        while (bag.TryTake(out result))
        {
            Console.WriteLine("Taken item: {0}", result);
        }
    }

    static void EnumeratingConcurrentBag()
    {
        ConcurrentBag<int> bag = new ConcurrentBag<int>();
        Task.Run(() =>
        {
            bag.Add(42);
            Thread.Sleep(100);
            bag.Add(21);
        });

        Task.Run(() =>
        {
            foreach (int i in bag)
            {
                Console.WriteLine(i);
            }
        }).Wait();
    }
}