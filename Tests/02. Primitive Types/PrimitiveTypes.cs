using System;
class Program
{
    static void Main()
    {
        // Problem 03
        decimal a = 0.000001m;
        decimal result = 0;
        for (int i = 0; i < 1000000; i++)
        {
            result += a;
        }

        Console.WriteLine(result);

        // Problem 04
        int b = 0x100;
        Console.WriteLine(b);

        // Problem 05
        char c = '\u0048';
        Console.WriteLine(c);

        // Problem 07
        string hello = "Hello";
        string world = "World";
        object helloWorld = hello + " " + world;
        Console.WriteLine(helloWorld);

        // Problem 08
        string helloWorldString = (string)helloWorld;
        Console.WriteLine(helloWorldString);

        // Problem 09
        Console.WriteLine();
        string quotedString = "The \"use\" of quotations causes difficulties.";
        string unquotedString = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(quotedString);
        Console.WriteLine(unquotedString);

        // Problem 10
        Console.WriteLine("  ooo  ooo  ");
        Console.WriteLine(" oooooooooo ");
        Console.WriteLine("oooooooooooo");
        Console.WriteLine(" oooooooooo ");
        Console.WriteLine("   oooooo   ");
        Console.WriteLine("     oo     ");

        // Problem 11
        char copy = '\u00A9';
        Console.WriteLine("  " + copy + "  ");
        Console.WriteLine(" " + new string(copy, 3) + " ");
        Console.WriteLine(new string(copy, 5));

        // Problem 13
        int num1 = 5;
        int num2 = 10;
        num1 ^= num2;
        num2 ^= num1;
        num1 ^= num2;
        Console.WriteLine(num1);
        Console.WriteLine(num2);

        num1 = num1 + num2;
        num2 = num1 - num2;
        num1 = num1 - num2;
        Console.WriteLine(num1);
        Console.WriteLine(num2);
    }
}