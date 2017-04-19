using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

class UsingConcurrntStack
{
    static void Main()
    {
        ConcurrentStack<int> stack = new ConcurrentStack<int>();

        stack.Push(42);

        int result;
        if (stack.TryPop(out result))
        {
            Console.WriteLine("Popped: {0}", result);
        }

        stack.PushRange(new int[] { 1, 2, 3 });

        int[] values = new int[2];
        stack.TryPopRange(values);

        foreach (int i in values)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("------");
        UsingConcurrntQueue();
    }

    static void UsingConcurrntQueue()
    {
        ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        queue.Enqueue(42);

        int result;
        if (queue.TryDequeue(out result))
        {
            Console.WriteLine(result);
        }
    }
}