using System;
using System.Runtime.InteropServices;
using System.Security;

class InitializingSecureString
{
    static void Main()
    {
        using (SecureString ss = new SecureString())
        {
            Console.Write("Enter password: ");
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    break;
                }

                if (cki.Key == ConsoleKey.Backspace && ss.Length > 0)
                {
                    ss.RemoveAt(ss.Length - 1);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }

                if (cki.Key != ConsoleKey.Backspace && cki.Key != ConsoleKey.Escape)
                {
                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }
            }

            ss.MakeReadOnly();

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(ss);
                Console.WriteLine();
                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}