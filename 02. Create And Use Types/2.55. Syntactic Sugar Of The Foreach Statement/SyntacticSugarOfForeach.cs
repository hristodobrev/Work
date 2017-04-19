using System;
using System.Collections.Generic;

class SyntacticSugarOfForeach
{
    static void Main()
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 5, 7, 9 };
        using (List<int>.Enumerator enumerator = numbers.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}