using System;
using System.Collections.Generic;

class ChangingForeachItems
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

        foreach (Person p in people)
        {
            p.LastName = "Changed";
            // p = new Person() { FirstName = "Ganka", LastName = "Petrankova" }; // Not allowed
        }

        foreach (Person p in people)
        {
            Console.WriteLine(p);
        }
    }
}