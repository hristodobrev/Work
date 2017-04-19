using System;
using System.Linq;

class UsingORM
{
    static void Main()
    {
        //AddPerson(new Person("Georgi Vasilev"));
        //RemovePerson(7);

        using (PeopleContext ctx = new PeopleContext())
        {
            var persons = ctx.People.ToArray();
            foreach (Person p in persons)
            {
                Console.WriteLine(p);
            }
        }
    }

    static void AddPerson(Person p)
    {
        using (PeopleContext ctx = new PeopleContext())
        {
            ctx.People.Add(p);
            ctx.SaveChanges();
        }
    }

    static void RemovePerson(int id)
    {
        using (PeopleContext ctx = new PeopleContext())
        {
            var person = ctx.People.SingleOrDefault(p => p.Id == id);
            if (person != null)
            {
                ctx.People.Remove(person);
            }
            ctx.SaveChanges();
        }
    }

    static void RemovePerson(string name)
    {
        using (PeopleContext ctx = new PeopleContext())
        {
            var person = ctx.People.SingleOrDefault(p => p.Name == name);
            if (person != null)
            {
                ctx.People.Remove(person);
            }
            ctx.SaveChanges();
        }
    }
}