using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

class UsingBlockingCollection
{
    static void Main()
    {
        BlockingCollection<string> col = new BlockingCollection<string>();
        Task read = Task.Run(() =>
        {
            //while (true)
            //{
            //    Console.WriteLine(col.Take());
            //}

            foreach (string str in col.GetConsumingEnumerable())
            {
                Console.WriteLine(str);
            }
        });

        Task write = Task.Run(() =>
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s))
                {
                    break;
                }
                col.Add(s);
            }
        });

        // Testing TryTake
        BlockingCollection<int> intCol = new BlockingCollection<int>();
        intCol.Add(12);
        intCol.Add(24);
        intCol.Add(65);
        intCol.Add(123);
        List<int> nums = new List<int>();
        bool taken = true;
        while (taken)
        {
            int a;
            taken = intCol.TryTake(out a);
            if (a != 0)
            {
                nums.Add(a);
            }
        }
        Console.WriteLine(String.Join(", ", nums));

        write.Wait();
    }
}
