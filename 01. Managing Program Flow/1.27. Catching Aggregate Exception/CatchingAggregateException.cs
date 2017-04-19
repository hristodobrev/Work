using System;
using System.Linq;

class CatchingAggregateException
{
    static void Main()
    {
        var numbers = Enumerable.Range(0, 20);

        try
        {
            var parallelResult = numbers.AsParallel()
                .Where(i => IsEvent(i));

            parallelResult.ForAll(e => Console.WriteLine(e));
        }
        catch (AggregateException e)
        {
            Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count);
        }
    }

    public static bool IsEvent(int i)
    {
        if (i % 10 == 0)
        {
            throw new ArgumentException("i");
        }

        return i % 2 == 0;
    }
}