using System;
using System.IO;

class WorkingWithPaths
{
    static void Main()
    {
        string folder = @"F:\temp\Test Directory\Subdirectory";
        string fileName = "test.dat";

        // Wrong way
        string wrongPath = folder + fileName;
        Console.WriteLine(wrongPath);

        // Right way
        string rightPath = Path.Combine(folder, fileName);
        Console.WriteLine(rightPath);

        Console.WriteLine(Path.GetDirectoryName(rightPath));
        Console.WriteLine(Path.GetExtension(rightPath));
        Console.WriteLine(Path.GetFileName(rightPath));
        Console.WriteLine(Path.GetPathRoot(rightPath));
    }
}