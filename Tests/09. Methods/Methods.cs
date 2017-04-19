using System;

class Methods
{
    static void Main()
    {
        // Console.WriteLine(GetRectangleArea(10, 2.5));
        // int a = 10;
        // ChangeRefValue(ref a);
        // Console.WriteLine(a);
        // ChangeValue(a);
        // Console.WriteLine(a);
        // PrintNumbers(new float[] { 121, 54365, 324, 4523 });
        
        // PrintNums(1, 2); // Compiler Error
    }

    static void PrintNums(float fValue, int iValue)
    {
        Console.WriteLine(fValue + "; " + iValue);
    }

    static void PrintNums(int iValue, float fValue)
    {
        Console.WriteLine(iValue + "; " + fValue);
    }

    static void PrintNumbers(params float[] numbers)
    {
        foreach (var num in numbers)
        {

            Console.WriteLine("The number is: {0}", num);
        }
    }

    static void ChangeValue(int a)
    {
        a = 50;
    }

    static void ChangeRefValue(ref int a)
    {
        a = 5;
    }

    static double GetRectangleArea(double width, double height)
    {
        return width * height;
    }

    static void MethodOne()
    {
        Console.WriteLine("This is the first Message.");

        MethodTwo();

        Console.WriteLine("This is the third Message.");
    }

    static void MethodTwo()
    {
        Console.WriteLine("This is the second Message.");
    }
}