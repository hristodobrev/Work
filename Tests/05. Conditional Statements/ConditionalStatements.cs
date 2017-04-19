using System;

class ConditionalStatements
{
    static void Main()
    {
        string a = "Text";
        string b = a;
        string c = "Te" + 'x' + "t";
        Console.WriteLine(a == b);
        Console.WriteLine((object)a == (object)b);
        Console.WriteLine(a == c);
        Console.WriteLine((object)a == (object)c);

    }
}