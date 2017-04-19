using System;
using System.Linq;

class NumeralSystems
{
    static void Main()
    {
        // Console.WriteLine(sum);

        // Console.WriteLine(decSum);

        // Console.WriteLine(Single.Epsilon);

        // Console.WriteLine(BinToDecHorner("11000"));

        // Console.WriteLine((char)65); // A

        // Console.WriteLine(ConvertNumeralSystem("5467546762345756", 10, 32));

        decimal num = 0.000001m;
        decimal sum = 0m;
        for (int i = 0; i < 50000000; i++)
        {
            sum += num;
        }

        Console.WriteLine(sum);
    }

    static string ConvertNumeralSystem(string num, int s, int d)
    {
        string convertedNum = "";
        int decNum = 0;
        for (int i = num.Length - 1, pow = 0; i >= 0; i--, pow++)
        {
            decNum += GetValue(num[i]) * (Power(s, pow));
        }

        while (decNum > 0)
        {
            int remainder = decNum % d;
            convertedNum += GetChar(remainder);
            decNum /= d;
        }

        return String.Join("", convertedNum.Reverse());
    }

    static char GetChar(int num)
    {
        if (num < 10)
        {
            return num.ToString()[0];
        }
        else
        {
            return (char)(num + 55);
        }
    }

    static int GetValue(char character)
    {
        int num = 0;
        bool parsed = int.TryParse("" + character, out num);
        if (parsed)
        {
            return num;
        }
        else
        {
            return (int)(Char.ToUpper(character)) - 55;
        }
    }

    static int BinToDecHorner(string binNum)
    {
        int decNum = 0;

        for (int i = 0; i < binNum.Length; i++)
        {
            decNum = decNum * 2 + int.Parse("" + binNum[i]);
        }

        return decNum;
    }

    static string BinToHex(string binNum)
    {
        if (binNum.Length % 4 != 0)
        {
            int padding = 4 - (binNum.Length % 4);
            binNum = new String('0', padding) + binNum;
        }

        string hexNum = "";
        for (int i = 0; i < binNum.Length; i += 4)
        {
            int num = BinToDec(binNum.Substring(i, 4));
            if (num > 9)
            {
                switch (num)
                {
                    case 10: hexNum += "A"; break;
                    case 11: hexNum += "B"; break;
                    case 12: hexNum += "C"; break;
                    case 13: hexNum += "D"; break;
                    case 14: hexNum += "E"; break;
                    case 15: hexNum += "F"; break;
                }
            }
            else
            {
                hexNum += num;
            }
        }

        return hexNum;
    }

    static int BinToDec(string binNum)
    {
        int decNum = 0;
        for (int index = binNum.Length - 1, pow = 0; index >= 0; index--, pow++)
        {
            if (binNum[index] == '1')
            {
                decNum += Power(2, pow);
            }
        }

        return decNum;
    }

    static int Power(int num, int pow)
    {
        int sum = 1;
        for (int i = 0; i < pow; i++)
        {
            sum *= num;
        }

        return sum;
    }
}