using System;
using System.IO;

class DeletingAFile
{
    static void Main()
    {
        string path = @"test.txt";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        FileInfo fileInfo = new FileInfo(path);
        if (fileInfo.Exists)
        {
            fileInfo.Delete();
        }
    }
}