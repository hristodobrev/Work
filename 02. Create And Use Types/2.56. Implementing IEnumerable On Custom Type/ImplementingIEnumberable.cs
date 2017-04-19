using System;
using System.Collections;
using System.Collections.Generic;

class Person
{
    public Person(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public override string ToString()
    {
        return this.FirstName + " " + this.LastName;
    }
}

class People : IEnumerable<Person>
{
    public People(Person[] people)
    {
        this.people = people;
    }

    Person[] people;

    public IEnumerator<Person> GetEnumerator()
    {
        for (int index = 0; index < people.Length; index++)
        {
            yield return people[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class ImplementingIEnumberable
{
    static void Main()
    {

    }
}