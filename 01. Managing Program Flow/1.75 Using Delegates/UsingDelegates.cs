using System;

class UsingDelegates
{
    public delegate int Calculate(int x, int y);

    public delegate void Del();

    static void Main()
    {
        Del d = MethodOne;
        d += MethodTwo;
        d += UseDelegate;

        int invocationCount = d.GetInvocationList().GetLength(0);
        Console.WriteLine(invocationCount);

        d();

        // UseDelegate();
    }

    public static void MethodOne()
    {
        Console.WriteLine("MethodOne");
    }

    public static void MethodTwo()
    {
        Console.WriteLine("MethodTwo");
    }

    public static void UseDelegate()
    {
        Calculate calc = Add;
        Console.WriteLine(calc(3, 4));

        calc = Multiply;
        Console.WriteLine(calc(3, 4));

        Test(calc);
    }

    public static void Test(Calculate a)
    {
        Console.WriteLine(a(5, 10));
    }

    public static int Add(int x, int y) { return x + y; }

    public static int Multiply(int x, int y) { return x * y; }


}