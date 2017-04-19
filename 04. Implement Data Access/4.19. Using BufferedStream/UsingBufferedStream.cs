using System;
using System.IO;

class UsingBufferedStream
{
    static void Main()
    {
        string path = "bufferedStream.txt";

        using (FileStream fileStream = File.Create(path))
        {
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            {
                using (StreamWriter streamWriter = new StreamWriter(bufferedStream))
                {
                    streamWriter.WriteLine("A line of text.");
                }
            }
        }
    }
}