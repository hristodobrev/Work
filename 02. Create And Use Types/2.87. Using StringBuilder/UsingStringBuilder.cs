using System;
using System.Text;
class UsingStringBuilder
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder("A initial value");
        sb[0] = 'B';
        Console.WriteLine(sb);

        StringBuilder sb2 = new StringBuilder(string.Empty);
        for (int i = 0; i < 100000000; i++)
        {
            sb2.Append("x");
        }
        Console.WriteLine("Concatenated StringBuilder");

        string str = new String('x', 100000000);
        Console.WriteLine("Concatenated new String('x', 100000000)");
    }
}