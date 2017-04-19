using System;

class CreatingCustomCollection
{
    static void Main()
    {
        Person p1 = new Person("John", "Doe", 42);
        Person p2 = new Person("Jane", "Doe", 21);

        PeopleCollection people = new PeopleCollection();
        people.Add(p1);
        people.Add(p2);

        Console.WriteLine(people);
        people.RemoveByAge(42);
        Console.WriteLine(people.Count);
    }
}