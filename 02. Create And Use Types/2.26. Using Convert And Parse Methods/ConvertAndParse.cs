using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;

class Person
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public override string ToString()
    {
        return string.Format("{0} - {1}", this.Name, this.Age);
    }

    public static Person Parse(string s)
    {
        var tokens = s.Split(new char[] { ' ', '-', ',', ':', '=' }, StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length != 2)
        {
            throw new ArgumentException("There must be only two parameters: name and age");
        }

        return new Person(tokens[0], int.Parse(tokens[1]));
    }
}

class ConvertAndParse
{
    static void Main()
    {
        Person p = new Person("Pesho", 16);
        Console.WriteLine(p);

        Person p2 = Person.Parse("Penka - 12");
        Console.WriteLine(p2);

        int value = int.Parse("42");
        value = Convert.ToInt32("42");
        bool success = int.TryParse("42", out value);
        Console.WriteLine(value);
    }

    void OpenConnection(DbConnection connection)
    {
        if (connection is SqlConnection)
        {

        }
    }

    void LogStream(Stream stream)
    {
        MemoryStream memoryStream = stream as MemoryStream;
        if (memoryStream != null)
        {

        }
    }
}