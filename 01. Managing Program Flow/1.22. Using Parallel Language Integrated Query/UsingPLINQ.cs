using System;
using System.Linq;

class UsingPLINQ
{
    static void Main()
    {
        // Normal way
        var nums = Enumerable.Range(0, 30);
        var result = nums.Where(i => i % 2 == 0)
            .ToArray();
        // Console.WriteLine(String.Join(", ", result));

        // Parallel way
        var numbers = Enumerable.Range(0, 30);
        var parallelResult = numbers
            .AsParallel()
            .Where(i => i % 2 == 0)
            .ToArray();
        // Console.WriteLine(String.Join(", ", parallelResult));

        // Parallel Ordered way
        var ordNumbers = Enumerable.Range(0, 30);
        var parallelOrderedResult = ordNumbers
            .AsParallel()
            .AsOrdered()
            .Where(i =>
            {
                Console.WriteLine(i);
                return i % 2 == 0;
            })
            .ToArray();
        // Console.WriteLine(String.Join(", ", parallelOrderedResult));

        // Parallel Ordered Sequental way
        var ordSeqNumbers = Enumerable.Range(0, 30);
        var parallelOrderedSequentalResult = ordSeqNumbers
            .AsParallel()
            .AsOrdered()
            .Where(i =>
            {
                Console.WriteLine(i);
                return i % 2 == 0;
            })
            .AsSequential()
            .ToArray();
        // Console.WriteLine(String.Join(", ", parallelOrderedSequentalResult));

        // ForAll
        var numbs = Enumerable.Range(0, 20);
        var pResult = numbers.AsParallel()
            .Where(i => i % 2 == 0);

        pResult.ForAll(e => Console.WriteLine(e));
    }
}