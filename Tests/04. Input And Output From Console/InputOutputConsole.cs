using System;
using System.Linq;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;

enum Test
{
    Hundred = 100,
    Thousand = 1000
}

class InputOutputConsole
{
    static void Main()
    {
        // Problem 01
        //int[] nums = Console.ReadLine()
        //    .Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries)
        //    .Select(int.Parse)
        //    .ToArray();

        //Console.WriteLine(nums.Sum());

        // Problem 02
        //string firstName, lastName, site, manager;
        //int phone, fax;
        //Console.Write("Please enter first name: ");
        //firstName = Console.ReadLine();
        //Console.Write("Please enter last name: ");
        //lastName = Console.ReadLine();
        //Console.Write("Please enter phone: ");
        //phone = int.Parse(Console.ReadLine());
        //Console.Write("Please enter fax: ");
        //fax = int.Parse(Console.ReadLine());
        //Console.Write("Please enter website: ");
        //site = Console.ReadLine();
        //Console.Write("Please enter manager: ");
        //manager = Console.ReadLine();

        //Console.WriteLine();
        //Console.WriteLine("Hello, {0} {1}", firstName, lastName);
        //Console.WriteLine("Your phone number is: {0:0#########}", phone);
        //Console.WriteLine("Your fax number is: {0:0#########}", fax);
        //Console.WriteLine("Your website is: {0}", site);
        //Console.WriteLine("Your manager is: {0}", manager);

        // Problem 03
        //int[] numbers = Console.ReadLine()
        //    .Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries)
        //    .Select(int.Parse)
        //    .ToArray();

        //Console.WriteLine("|{0,-10:X}|{1,-10:0.00}|{2,-10:0.00}|", numbers[0], numbers[1], numbers[2]);

        // Problem 07
        int[] nums = new int[5];
        for (int i = 0; i < 5; i++)
        {
            int num;
            Console.Write("Please enter a number: ");
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Please enter a valid number: ");
            }
            nums[i] = num;
        }

        Console.WriteLine(nums.Max());

        // Problem 11
        List<ulong> fibonacciNumbers = new List<ulong>();
        fibonacciNumbers.Add(0);
        fibonacciNumbers.Add(1);
        fibonacciNumbers.Add(1);
        for (int i = 3; i < 100; i++)
        {
            ulong currentNum;
            checked { currentNum = fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2]; }
            fibonacciNumbers.Add(currentNum);
        }
        Console.WriteLine(string.Join(", ", fibonacciNumbers));

        // Problem 12
        double sum = 1;
        double oldSum = 0;
        int denominator = 2;
        while (sum - oldSum > 0.001d)
        {
            oldSum = sum;
            if (denominator % 2 == 0)
            {
                sum += 1.0 / denominator;
            }
            else
            {
                sum -= 1.0 / denominator;
            }
            denominator++;
        }
        Console.WriteLine(sum);
    }

    static void Tests()
    {
        Console.WriteLine("{0,10:C}", 123);
        Console.WriteLine("{0,10:X}", 1234);
        Console.WriteLine("{0,10:P0}", 1.2);
        Console.WriteLine("{0:#.00##}", 1.23456);
        Console.WriteLine("{0:##.##%}", 0.24678);

        Console.WriteLine("{0:d}", DateTime.Now);
        Console.WriteLine("{0:D}", DateTime.Now);
        Console.WriteLine("{0:t}", DateTime.Now);
        Console.WriteLine("{0:T}", DateTime.Now);
        Console.WriteLine("{0:Y}", DateTime.Now);
        Console.WriteLine("{0:dd/MM/yyyy}", DateTime.Now);

        Console.WriteLine("{0:G}", Test.Hundred);
        Console.WriteLine("{0:D}", Test.Hundred);
        Console.WriteLine("{0:X}", Test.Hundred);
        Console.WriteLine("{0:G}", Test.Thousand);
        Console.WriteLine("{0:D}", Test.Thousand);
        Console.WriteLine("{0:X}", Test.Thousand);

        DateTime date = DateTime.Now;
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        Console.WriteLine(date);

        //var input = Console.ReadLine();
        //Console.WriteLine("{0}", input);

        //int codeRead = 0;
        //do
        //{
        //    codeRead = Console.Read();
        //    if (codeRead != 0)
        //    {
        //        Console.Write((char)codeRead);
        //    }
        //}
        //while (codeRead != 10);

        string str = Console.ReadLine();
        int intValue;

        bool parseSuccess = int.TryParse(str, out intValue);
        Console.WriteLine(parseSuccess ? "The square of the number is " + intValue * intValue + "." : "Invalid Number");

        ConsoleKeyInfo key = Console.ReadKey();
        Console.WriteLine();
        Console.WriteLine("Key entered: " + key.KeyChar);
        Console.WriteLine("Modifiers: " + key.Modifiers);

        Console.Write("Enter person name: ");
        string person = Console.ReadLine();
        Console.Write("Enter book name: ");
        string book = Console.ReadLine();
        string from = "Authors Team";
        Console.WriteLine("Dear {0},", person);
        Console.Write("We are pleased to inform " +
        "you that \"{1}\" is the best Bulgarian book. {2}" +
        "The authors of the book wish you good luck {0}!{2}",
        person, book, Environment.NewLine);
        Console.WriteLine("Yours,");
        Console.WriteLine("{0}", from);
    }
}