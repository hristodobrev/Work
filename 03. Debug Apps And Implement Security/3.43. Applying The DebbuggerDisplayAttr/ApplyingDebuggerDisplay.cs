using System;
using System.Diagnostics;

[DebuggerDisplay("Name = {FirstName} {LastName}")]
class Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}

class ApplyingDebuggerDisplay
{
    static void Main()
    {
        var p = new Person() { FirstName = "Penka", LastName = "Pencheva" };
        Console.WriteLine(p);
    }
}