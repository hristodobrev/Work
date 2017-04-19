using System;
public class Person
{
    protected string name;

    public Person(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return this.name; }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty.", "name");
            }

            this.name = value;
        }
    }

    public void SayName()
    {
        System.Console.WriteLine(this.name);
    }
}