using System;
using System.IO;

class CreatingANewDirectory
{
    static void Main()
    {
        var directory = Directory.CreateDirectory(@"Directory");
        //directory.Delete();
        //directory.Create();
        var directories = directory.EnumerateDirectories();
        foreach (var dir in directories)
        {
            Console.WriteLine(dir.Name);
        }

        //var directoryInfo = new DirectoryInfo(@"D:\Temp\ProgrammingInCSharp\DirectoryInfo");
        //directoryInfo.Create();
        if (Directory.Exists(@"D:\Temp"))
        {
            Directory.Delete(@"D:\Temp", true);
        }

        DirectoryInfo di = new DirectoryInfo(@"D:\Temp");

        FileAttributes attributes = di.Attributes;

        Console.WriteLine(attributes);
    }
}