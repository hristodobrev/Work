using System;
using System.IO;

class BuildingADirectoryTree
{
    static void Main()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Program Files");
        ListDirectories(directoryInfo, "*a*", 5, 0);
    }

    static void ListDirectories(DirectoryInfo directoryInfo, string pattern,
        int maxLevel, int currentLevel)
    {
        if (currentLevel >= maxLevel)
        {
            return;
        }

        string indent = StringRepeat("| ", currentLevel) + "+-";

        try
        {
            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories(pattern);
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                Console.WriteLine(indent + subDirectory.Name);
                ListDirectories(subDirectory, pattern, maxLevel, currentLevel + 1);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Cannot access: " + directoryInfo.Name);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Cannot find: " + directoryInfo.Name);
        }
    }

    static string StringRepeat(string str, int count)
    {
        string result = "";

        for (int i = 0; i < count; i++)
        {
            result += str;
        }

        return result;
    }
}