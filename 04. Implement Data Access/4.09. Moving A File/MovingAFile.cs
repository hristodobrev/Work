using System;
using System.IO;

class MovingAFile
{
    static void Main()
    {
        string path = @"test.txt";
        string destPath = @"destTest.txt";

        var file = File.CreateText(path);
        file.WriteLine("Some test text");
        file.Close();
        File.Move(path, destPath);

        FileInfo fileInfo = new FileInfo(destPath);
        fileInfo.CopyTo("testCopy.txt");
    }
}