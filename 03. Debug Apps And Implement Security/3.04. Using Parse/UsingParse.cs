using System;

class UsingParse
{
    static void Main()
    {
        string value = "true";
        bool b = bool.Parse(value);

        Console.WriteLine(b);

        value = "10";
        int result;
        bool success = int.TryParse(value, out result);

        if (success)
        {
            Console.WriteLine("Successfully converted {0} to integer.", value);
        }
        else
        {
            Console.WriteLine("{0} is not a valid integer.", value);
        }
    }
}