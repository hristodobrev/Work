using System;
using System.Collections.Generic;

class Arrays
{
    static void Main()
    {
        // var arr = new double[] { 1.56, 2.327, 3.754, 4.76 };
        // Console.WriteLine(arr.Print());
        // PascalTriangle();
        // LongestEqualSequenceInArray();
        // LongestIncreasingSequenceInArray();
        // LongestIncreasingSequence();
        // SelectionSort();
        LongestIncreasingSequence();
    }

    static void SelectionSort()
    {
        int[] arr = { 1, 6, 3, 7, 8, 4, 2, -4, 5, -6, -3 };
        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minIndex = index;
            for (int x = index + 1; x < arr.Length; x++)
            {
                if (arr[x] < arr[minIndex])
                {
                    minIndex = x;
                }
            }
            int temp = arr[index];
            arr[index] = arr[minIndex];
            arr[minIndex] = temp;
        }

        Console.WriteLine(String.Join(", ", arr));
    }

    static void LongestIncreasingSequence()
    {
        int[] seq = { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
        int[] len = new int[seq.Length];
        int[] prev = new int[seq.Length];

        int maxIndex = -1;
        int maxLength = 0;

        for (int x = 0; x < seq.Length; x++)
        {
            len[x] = 1;
            prev[x] = -1;
            for (int i = 0; i < x; i++)
            {
                if (seq[i] < seq[x] && len[i] + 1 > len[x])
                {
                    len[x] = 1 + len[i];
                    prev[x] = i;
                }
            }

            if (len[x] > maxLength)
            {
                maxLength = len[x];
                maxIndex = x;
            }
        }

        List<int> lis = new List<int>();
        while (maxIndex != -1)
        {
            lis.Add(seq[maxIndex]);
            maxIndex = prev[maxIndex];
        }

        lis.Reverse();
        Console.WriteLine(String.Join(", ", lis));
    }

    static void LongestIncreasingSequenceInArray()
    {
        int[] arr = { 1, 5, 5, 5, 3, 3, 4, 5, 2, 2, 1, 1, 2, 2, 2, 2, 3, 4, 5 };
        int bestStart = 0;
        int bestLength = 1;
        int start = bestStart;
        int length = bestLength;

        for (int index = 1; index < arr.Length; index++)
        {
            if (arr[index] > arr[index - 1])
            {
                length++;
            }
            else
            {
                start = index;
                length = 1;
            }

            if (bestLength < length)
            {
                bestLength = length;
                bestStart = start;
            }
        }

        for (int i = bestStart; i < bestStart + bestLength; i++)
        {
            Console.Write("{0} ", arr[i]);
        }
        Console.WriteLine();
    }

    static void LongestEqualSequenceInArray()
    {
        int[] arr = { 1, 5, 5, 5, 3, 3, 4, 2, 2, 1, 1, 2, 2, 2, 2 };
        int bestStart = 0;
        int bestLength = 1;
        int start = bestStart;
        int length = bestLength;

        for (int index = 1; index < arr.Length; index++)
        {
            if (arr[index] == arr[start])
            {
                length++;
            }
            else
            {
                start = index;
                length = 1;
            }

            if (bestLength < length)
            {
                bestLength = length;
                bestStart = start;
            }
        }

        Console.WriteLine(arr[bestStart]);
    }

    static void PascalTriangle()
    {
        int height = 10;
        long[][] triangle = new long[height + 1][];
        for (int row = 0; row < height; row++)
        {
            triangle[row] = new long[row + 1];
        }

        triangle[0][0] = 1;

        for (int row = 0; row < height - 1; row++)
        {
            for (int col = 0; col < triangle[row].Length; col++)
            {
                triangle[row + 1][col] += triangle[row][col];
                triangle[row + 1][col + 1] += triangle[row][col];
            }
        }

        for (int row = 0; row < height; row++)
        {
            Console.Write("".PadLeft((height - row) * 2));
            for (int col = 0; col < triangle[row].Length; col++)
            {
                Console.Write("{0,3} ", triangle[row][col]);
            }
            Console.WriteLine();
        }
    }
}

internal static class ExtensionMethods
{
    public static string Print(this int[] arr)
    {
        return "[" + String.Join(", ", arr) + "]";
    }

    public static string Print(this string[] arr)
    {
        return "[" + String.Join(", ", arr) + "]";
    }

    public static string Print(this double[] arr)
    {
        return "[" + String.Join(", ", arr) + "]";
    }

    public static string Print(this float[] arr)
    {
        return "[" + String.Join(", ", arr) + "]";
    }

    public static string Print(this decimal[] arr)
    {
        return "[" + String.Join(", ", arr) + "]";
    }

    public static string Print(this long[] arr)
    {
        return "[" + String.Join(", ", arr) + "]";
    }
}