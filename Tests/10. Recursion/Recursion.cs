using System;
using System.Collections.Generic;

class Recursion
{
    static ulong[] fibNums;

    static int numberOfLoops;
    static int numberOfIterations;
    static int[] loops;

    static char[,] lab =
    {
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', '*', '*', '*', '*', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
    };

    static char[] path = new char[lab.GetLength(0) * lab.GetLength(1)];
    static int position = 0;

    static void FindPath(int row, int col, char direction)
    {
        if ((col < 0) || (row < 0) ||
            (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)))
        {
            return;
        }

        path[position] = direction;
        position++;

        if (lab[row, col] == 'e')
        {
            PrintPath(path, 1, position - 1);
        }

        if (lab[row, col] == ' ')
        {
            lab[row, col] = 's';

            FindPath(row, col - 1, 'L');
            FindPath(row - 1, col, 'U');
            FindPath(row, col + 1, 'R');
            FindPath(row + 1, col, 'D');

            // lab[row, col] = ' ';
        }

        position--;
    }

    static void PrintPath(char[] path, int startPos, int endPos)
    {
        Console.Write("Found path to the exit: ");
        for (int pos = startPos; pos <= endPos; pos++)
        {
            Console.Write(path[pos]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        FindPath(0, 0, 'S');
    }

    static void IterativeNestedLoops()
    {
        InitLoops();

        int currentPosition;

        while (true)
        {
            PrintLoops();

            currentPosition = numberOfLoops - 1;

            loops[currentPosition]++;
            while (loops[currentPosition] > numberOfIterations)
            {
                loops[currentPosition] = 1;
                currentPosition--;

                if (currentPosition < 0)
                {
                    return;
                }

                loops[currentPosition]++;
            }
        }
    }

    static void InitLoops()
    {
        for (int i = 0; i < numberOfLoops; i++)
        {
            loops[i] = 1;
        }
    }

    static void NestedLoops(int currentLoop)
    {
        if (currentLoop == numberOfLoops)
        {
            PrintLoops();
            return;
        }

        for (int counter = 1; counter <= numberOfIterations; counter++)
        {
            loops[currentLoop] = counter;
            NestedLoops(currentLoop + 1);
        }
    }

    static void PrintLoops()
    {
        for (int i = 0; i < numberOfLoops; i++)
        {
            Console.Write("{0} ", loops[i]);
        }
        Console.WriteLine();
    }

    static decimal Factorial(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        return n * Factorial(n - 1);
    }

    static ulong Fib(int n)
    {
        if (fibNums[n] == 0)
        {
            fibNums[n] = Fib(n - 1) + Fib(n - 2);
        }

        return fibNums[n];
    }
}