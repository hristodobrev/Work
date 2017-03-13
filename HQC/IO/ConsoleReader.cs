
using System;
namespace HQC.IO
{
    public class ConsoleReader : IReader
    {
        public int Read()
        {
            return Console.Read();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
