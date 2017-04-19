using System;
using System.IO;
using System.Text;

class UsingFileCreateText
{
    static void Main()
    {
        string path = @"test.dat";

        using (StreamWriter streamWriter = File.CreateText(path))
        {
            string value = "Some test value";
            streamWriter.Write(value);
        }

        using (FileStream fileStream = File.OpenRead(path))
        {
            byte[] data = new byte[fileStream.Length];

            for (int index = 0; index < fileStream.Length; index++)
            {
                data[index] = (byte)fileStream.ReadByte();
            }
            Console.WriteLine(Encoding.UTF8.GetString(data));
        }

        using (StreamReader streamReader = File.OpenText(path))
        {
            Console.WriteLine(streamReader.ReadLine());
        }
    }
}