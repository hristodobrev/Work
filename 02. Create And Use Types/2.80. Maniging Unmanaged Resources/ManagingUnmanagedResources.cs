using System;
using System.IO;

class ManagingUnmanagedResources
{
    static void Main()
    {
        using (StreamWriter stream = File.CreateText("temp.dat"))
        {
            stream.Write("Some data");
            throw new Exception();
            stream.Dispose();

            File.Delete("temp.dat");
        }
    }
}