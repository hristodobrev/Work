using System;
using System.Reflection;

class CallingAMethod
{
    class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    static void Main()
    {
        var calc = new Calculator();
        Console.WriteLine(calc.Add(354, 23));
    }
}