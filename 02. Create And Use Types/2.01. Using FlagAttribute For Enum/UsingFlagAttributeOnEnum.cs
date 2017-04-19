using System;

class UsingFlagAttributeOnEnum
{
    enum Days
    {
        None = 0x0,
        Sunday = 0x1,
        Monday = 0x2,
        Tuesday = 0x4,
        Wednesday = 0x8,
        Thursday = 0x10,
        Friday = 0x20,
        Saturday = 0x40,
    }

    struct PersonStruct // value type
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    class PersonClass // reference type
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    static void Main()
    {
        var day = Days.Thursday;
        Days readingDays = Days.Monday | Days.Saturday;

        var personStruct = new PersonStruct();
        personStruct.Name = "Ivancho";
        personStruct.Age = 16;
        Console.WriteLine(personStruct.Name);
        ChangePersonName(personStruct, "Dragancho");
        Console.WriteLine(personStruct.Name);

        Console.WriteLine();

        var personClass = new PersonClass();
        personClass.Name = "Ivancho";
        personClass.Age = 16;
        Console.WriteLine(personClass.Name);
        ChangePersonName(personClass, "Dragancho");
        Console.WriteLine(personClass.Name);
    }

    static void ChangePersonName(PersonStruct p, string newPersonName)
    {
        p.Name = newPersonName;
    }

    static void ChangePersonName(PersonClass p, string newPersonName)
    {
        p.Name = newPersonName;
    }
}