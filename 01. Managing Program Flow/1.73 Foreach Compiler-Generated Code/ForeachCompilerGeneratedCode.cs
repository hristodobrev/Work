using System;
using System.Collections.Generic;

class ForeachCompilerGeneratedCode
{
    class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return (FirstName ?? "") + " " + (LastName ?? "");
        }
    }

    static void Main()
    {
        var people = new List<Person>
        {
            new Person(){FirstName = "Ivanka", LastName = "Petrankova"},
            new Person(){FirstName = "Petranka", LastName = "Ivankova"},
        };

        List<Person>.Enumerator e = people.GetEnumerator();

        try
        {
            Person v;
            while (e.MoveNext())
            {
                v = e.Current;
                Console.WriteLine(v);
            }
        }
        finally
        {
            System.IDisposable d = e as System.IDisposable;
            if (d != null)
            {
                d.Dispose();
            }
        }
    }
}