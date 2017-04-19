using System;
using System.Collections.Generic;

public static class LinqExtensions
{
    public static IEnumerable<TSource> Where<TSource>(
       this IEnumerable<TSource> source,
       Func<TSource, bool> predicate)
    {
        foreach (TSource item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
}

class ImplementingWhere
{
    static void Main()
    {
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        Console.WriteLine(string.Join(", ", arr.Where(a => a % 2 == 0)));

    }
}