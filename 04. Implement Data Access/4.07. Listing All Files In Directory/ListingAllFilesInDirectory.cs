using System;
using System.IO;

class ListingAllFilesInDirectory
{
    static void Main()
    {
        foreach (string file in Directory.GetFiles(@"C:\Windows"))
        {
            Console.WriteLine(file);
        }

        Console.WriteLine();

        DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Windows");
        foreach (FileInfo fileInfo in directoryInfo.GetFiles())
        {
            Console.WriteLine(fileInfo.FullName);
        }
    }
}