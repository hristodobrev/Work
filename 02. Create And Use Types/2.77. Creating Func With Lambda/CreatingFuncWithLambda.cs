using System;
using System.Collections.Generic;
using System.Linq;

class CreatingFuncWithLambda
{
    static void Main()
    {
        Func<int, int, int> addFunc = (x, y) => x + y;
        Console.WriteLine(addFunc(2, 3));

        Exec((a, b) => a + b, 10, 20);

        int[] nums = new int[] { 67, 4, 78, 834, 8, 3 };
        var oddNums = nums.Filter(x => x % 2 == 1);
        Console.WriteLine(string.Join(", ", oddNums));

        var evenNums = nums.Where(x => x % 2 != 1);
        Console.WriteLine(string.Join(", ", evenNums));
    }

    static void Exec(Func<int, int, int> func, int a, int b)
    {
        Console.WriteLine(func(a, b));
    }
}

static class ArrayExtensions
{
    // Alternative to Where extension method
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> condition)
    {
        List<T> filteredCollection = new List<T>();
        foreach (T item in collection)
        {
            if (condition(item))
            {
                filteredCollection.Add(item);
            }
        }

        return filteredCollection;
    }
}