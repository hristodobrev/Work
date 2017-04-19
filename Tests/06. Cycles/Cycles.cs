using System;

class Cycles
{
    static void Main()
    {
        // Console.WriteLine(IsPrime(7));
        // Console.WriteLine(IsPrime(8));
        // Console.WriteLine(IsPrime(19));
        // Console.WriteLine(IsPrime(657113));
        try
        {
            Console.WriteLine(Factorial(20));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // HappyNumbers();
        // int n = int.Parse(Console.ReadLine());
        // decimal catalansNumber = Factorial(2 * n) / (Factorial(n + 1) * Factorial(n));
        // Console.WriteLine(catalansNumber);


        // Console.WriteLine(CountZeroesInFactorial(200000));
        // Console.WriteLine(Factorial(20));

        Console.WriteLine(BinToDec("11011010"));
        Console.WriteLine(DecToBin(BinToDec("11011010")));
        Console.WriteLine(Convert.ToString(155, 16));
        Console.WriteLine(Convert.ToString(4678, 16));
        Console.WriteLine(Convert.ToString(30, 16));
        Console.WriteLine(HexToDec("1246"));
        // RandomizeNumbers();
        // Console.WriteLine(GreaterCommonDivider(12, 41));
        PrintSpiralMatrix(4);
    }

    static void PrintSpiralMatrix(int n)
    {
        int[,] matrix = new int[n, n];
        char dir = 'r';
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int row = 0;
        int col = 0;
        int value = 1;

        while (value <= n * n)
        {
            matrix[row, col] = value;
            if (dir == 'r' && (col >= cols - 1 || (col < cols - 1 && matrix[row, col + 1] != 0)))
            {
                dir = 'd';
            }

            if (dir == 'd' && (row >= rows - 1 || (row < rows - 1 && matrix[row + 1, col] != 0)))
            {
                dir = 'l';
            }

            if (dir == 'l' && (col <= 0 || (col > 0 && matrix[row, col - 1] != 0)))
            {
                dir = 'u';
            }

            if (dir == 'u' && (row <= 0 || (row > 0 && matrix[row - 1, col] != 0)))
            {
                dir = 'r';
            }

            switch (dir)
            {
                case 'r':
                    col++;
                    break;
                case 'd':
                    row++;
                    break;
                case 'l':
                    col--;
                    break;
                case 'u':
                    row--;
                    break;
            }

            value++;
        }

        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                Console.Write("{0} ", matrix[currentRow, currentCol]);
            }
            Console.WriteLine();
        }
    }

    static int GreaterCommonDivider(int a, int b)
    {
        int dividend = Math.Max(a, b);
        int divisor = Math.Min(a, b);

        while (dividend % divisor != 0)
        {
            int remainder = dividend % divisor;
            dividend = divisor;
            divisor = remainder;
        }

        return divisor;
    }

    static void RandomizeNumbers()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        var rnd = new Random();
        for (int i = 0; i < numbers.Length; i++)
        {
            int randomIndex = rnd.Next(numbers.Length);
            while (randomIndex == i)
            {
                randomIndex = rnd.Next(numbers.Length);
            }

            numbers[i] = numbers[i] + numbers[randomIndex];
            numbers[randomIndex] = numbers[i] - numbers[randomIndex];
            numbers[i] = numbers[i] - numbers[randomIndex];
        }

        Console.WriteLine(String.Join(", ", numbers));
    }

    static int HexToDec(string hexNum)
    {
        // 3210 - indices
        //   9b = 155
        // 1246 = 4678
        //   1e = 30
        // hex = num[0]*16^index[0] + num[1]*16^index[1] +...+ num[n]*16^index[n]

        int decNum = 0;
        for (int index = hexNum.Length - 1, pow = 0; index >= 0; index--, pow++)
        {
            switch (hexNum[index])
            {
                case 'A':
                case 'a':
                    decNum += 10 * (Power(16, pow));
                    break;
                case 'B':
                case 'b':
                    decNum += 11 * (Power(16, pow));
                    break;
                case 'C':
                case 'c':
                    decNum += 12 * (Power(16, pow));
                    break;
                case 'D':
                case 'd':
                    decNum += 13 * (Power(16, pow));
                    break;
                case 'E':
                case 'e':
                    decNum += 14 * (Power(16, pow));
                    break;
                case 'F':
                case 'f':
                    decNum += 15 * (Power(16, pow));
                    break;
                default:
                    decNum += int.Parse("" + hexNum[index]) * (Power(16, pow));
                    break;
            }
        }

        return decNum;
    }

    static string DecToHex(int num)
    {
        return Convert.ToString(num, 16);
    }

    static int BinToDec(string binNum)
    {
        // 6543210 - indices
        //     101 = 5
        // 1011010 = 90
        // dec = 2^index + 2^index-1 +...+ 2^index-n

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

    static string DecToBin(int num)
    {
        return Convert.ToString(num, 2);
    }

    static int CountZeroesInFactorial(int n)
    {
        int zeroes = 0;
        for (int pow = 1; pow <= n / 5; pow++)
        {
            zeroes += n / (Power(5, pow));
        }

        return zeroes;
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

    static void HappyNumbers()
    {
        for (int a = 1; a <= 9; a++)
        {
            for (int b = 0; b <= 9; b++)
            {
                for (int c = 0; c <= 9; c++)
                {
                    for (int d = 0; d <= 9; d++)
                    {
                        if (a + b == c + d)
                        {
                            Console.WriteLine("" + a + b + c + d);
                        }
                    }
                }
            }
        }
    }

    static decimal Factorial(int n)
    {
        decimal factorial = 1;

        while (true)
        {
            if (n <= 1)
            {
                break;
            }

            factorial *= n;
            n--;
        }

        return factorial;
    }

    static bool IsPrime(int num)
    {
        int divider = 2;
        int maxDivider = (int)Math.Sqrt(num);

        while (divider <= maxDivider)
        {
            if (num % divider == 0)
            {
                return false;
            }
            divider++;
        }

        return true;
    }
}