using System;
using System.Linq;

static class ExtensionMethods
{
    public static int Multiply(this int x, int y)
    {
        return x * y;
    }
}

class UsingExtensionMethods
{
    static void Main()
    {
        int a = 10;
        Console.WriteLine(a.Multiply(20));

        var person = new
        {
            FirstName = "John",
            LastName = "Doe"
        };

        Console.WriteLine(person.GetType().Name + Environment.NewLine);

        int[] data = { 1, 2, 5, 8, 11 };

        var evens = from d in data
                     where d % 2 == 0
                     select d;
        Console.WriteLine("Even numbers: [{0}]", string.Join(", ", evens));

        var graterThan5 = from d in data
                          where d > 5
                          orderby d descending
                          select d;
        Console.WriteLine("Greather than 5: [{0}]", string.Join(", ", graterThan5));

        int[] data1 = { 1, 2, 5 };
        int[] data2 = { 2, 4, 6 };

        var result = from d1 in data1
                     from d2 in data2
                     select d1 * d2;
        Console.WriteLine("[1, 2, 5] * [2, 4, 6]: [{0}]", string.Join(", ", result));
    }
}