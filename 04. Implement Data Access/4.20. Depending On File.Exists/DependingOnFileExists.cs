using System;
using System.IO;

class DependingOnFileExists
{
    static void Main()
    {
        Console.WriteLine(ReadAllText());
    }

    static string ReadAllText()
    {
        string path = "test.txt";

        if (File.Exists(path))
        {
            return File.ReadAllText(path);
        }

        return string.Empty;
    }

    static string ReadAllTextHandled()
    {
        string path = "test.txt";

        try
        {
            return File.ReadAllText(path);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory {0} not found.", path);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File {0} not found.", path);
        }

        return string.Empty;
    }
}