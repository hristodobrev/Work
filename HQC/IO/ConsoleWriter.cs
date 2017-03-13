using System;
namespace HQC.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object text)
        {
            Console.Write(text);
        }

        public void WriteLine(object text)
        {
            Console.WriteLine(text);
        }

        public void Write(string text, object[] args)
        {
            Console.Write(text, args);
        }

        public void WriteLine(string text, object[] args)
        {
            Console.WriteLine(text, args);
        }
    }
}
