using System;
class Program
{
    static void Main()
    {
        // Problem 01
        int evenNum = 1235;
        Console.WriteLine("{0} is {1}", evenNum, (evenNum % 2 == 0) ? "even" : "odd");

        // Problem 02
        int divBy7And5 = 35;
        Console.WriteLine("{0} is{1} dividable by 5 and 7", divBy7And5, (divBy7And5 % 7 == 0 && divBy7And5 % 5 == 0) ? "" : " not");

        // Problem 03
        string strNum = "57.70";
        if (strNum.Length < 3)
        {
            Console.WriteLine(strNum + "'s 3rd digit is not 7");
        }
        else
        {
            strNum = strNum.Substring(strNum.Length - 3, 1);
            if (strNum == "7")
            {
                Console.WriteLine(strNum + "'s 3rd digit is 7");
            }
            else
            {
                Console.WriteLine(strNum + "'s 3rd digit is not 7");
            }
        }

        // Problem 04
        int bitNum = 12;
        int thirdBit = (bitNum >> 2) & 1;
        Console.WriteLine(thirdBit);

        // Problem 05
        double a = 6;
        double b = 4;
        double h = 5;
        double area = ((a + b) * h) / 2;
        Console.WriteLine(area);

        // Problem 07
        double earthsWeight = 65d;
        double moonsWeight = earthsWeight * 0.17;
        Console.WriteLine(moonsWeight + "kg");

        // Problem 10
        int num = 2011;
        int sumOfNumDigits = 0;
        while (num > 0)
        {
            sumOfNumDigits += num % 10;
            num /= 10;
        }
        Console.WriteLine(sumOfNumDigits);

        // Problem 11
        //int n = 35;
        //int p = 6;
        //int bitOnPositionP = (n & (1 << p)) >> p; // Same as (n >> p) & 1
        //Console.WriteLine(bitOnPositionP);

        // Problem 12
        //int v = 5;
        //int pv = 1;
        //bool isBitOnP1 = ((v >> pv) & 1) == 1;
        //Console.WriteLine(isBitOnP1);

        // Problem 13
        int n = 35;
        int p = 2;
        int v = 1;
        n = (n & ~(1 << p)) | (v << p);
        Console.WriteLine(n);

        int number = 83886088;
        int rightBits = ((7 << 3) & number) >> 3;
        int leftBits = ((7 << 24) & number) >> 24;
        number = number & ~(7 << 3);
        number = number & ~(7 << 24);
        number = number | (rightBits << 24);
        number = number | (leftBits << 3);
        Console.WriteLine(number);
    }

    static void Tests()
    {
        int expr = 6 / 2 + 2;
        Console.WriteLine(expr);

        Console.WriteLine(9 % -2);

        Console.WriteLine(5.0 / -0.0);

        // Console.WriteLine(true ^ false ^ (true ^ false) ^ true);

        bool a = true;
        bool b = false;
        Console.WriteLine(!(a || b) == (!a && !b));
        Console.WriteLine((a && b) == !(!a || !b));
        Console.WriteLine(!(a || b) == (!a && !b));
        Console.WriteLine((a || b) == !(!a && !b));

        Console.WriteLine(5 + 4 + " String");
        Console.WriteLine("String " + 5 + 4);

        var obj = new { a = 5, b = "Text" };
        Console.WriteLine(obj.a);
        Console.WriteLine(obj.b);

        int? num = null;
        Console.WriteLine(num ?? 0); // Print 0 if the number is null

        double bigNum = 5e9d;
        Console.WriteLine(bigNum);
        Console.WriteLine((int)bigNum);
        Console.WriteLine(int.MinValue);

        int checkedNum = checked((int)bigNum);
        Console.WriteLine(checkedNum);


    }
}