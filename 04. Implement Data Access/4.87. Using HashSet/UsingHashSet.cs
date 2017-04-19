using System;
using System.Collections.Generic;

class UsingHashSet
{
    static void Main()
    {
        HashSet<int> odds = new HashSet<int>();
        HashSet<int> evens = new HashSet<int>();

        for (int i = 1; i <= 10; i++)
        {
            if (i % 2 == 0)
            {
                evens.Add(i);
            }
            else
            {
                odds.Add(i);
            }
        }

        DisplaySet(odds);
        DisplaySet(evens);

        odds.UnionWith(evens);

        DisplaySet(odds);

        Queue<string> queueWords = new Queue<string>();
        queueWords.Enqueue("Hello");
        queueWords.Enqueue("world");
        queueWords.Enqueue("form");
        queueWords.Enqueue("a");
        queueWords.Enqueue("queue");

        foreach (var s in queueWords)
        {
            Console.Write(s + " ");
        }
        Console.WriteLine();

        Stack<string> stackWords = new Stack<string>();
        stackWords.Push("Hello");
        stackWords.Push("world");
        stackWords.Push("form");
        stackWords.Push("a");
        stackWords.Push("queue");

        foreach (var s in stackWords)
        {
            Console.Write(s + " ");
        }
        Console.WriteLine();
    }

    static void DisplaySet<T>(HashSet<T> set)
    {
        Console.Write("{");
        foreach (T i in set)
        {
            Console.Write(" {0}", i);
        }
        Console.WriteLine(" }");
    }
}