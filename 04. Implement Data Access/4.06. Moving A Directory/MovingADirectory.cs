using System;
using System.IO;

class MovingADirectory
{
    static void Main()
    {
        //Directory.Move(@"source", @"destination");

        //DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(@"source");
        //sourceDirectoryInfo.Create();
        //DirectoryInfo destinationDirectoryInfo = new DirectoryInfo(@"destination");
        //destinationDirectoryInfo.Create();

        // Searches for directory with name "source" and moves its CONTENT to a
        // new directory "destination" which must not exist!
        Directory.Move("source", "destination");
    }
}