using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UsingActionDelegate
{
    static void Main()
    {
        Func<int, int, string, int> calc = (x, y, str) =>
        {
            Console.WriteLine("Message: " + str);
            return x + y;
        };

        Console.WriteLine(calc(5, 6, "This is custom message."));

        Action<int, int> showNums = (x, y) =>
        {
            Console.WriteLine("Nums: {0}, {1}", x, y);
        };

        showNums(12, 67);
    }
}
