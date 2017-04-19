using System;
using System.Diagnostics;

[AttributeUsage(AttributeTargets.Class)]
public class MachineryAttribute : Attribute
{
    private string type;
    public double version;

    public MachineryAttribute(string type)
    {
        this.type = type;
        this.version = 1.0;
    }

    public string Type { get { return this.type; } }
}

[Serializable]
class Person { }

class Student : Person { }

[Machinery("Test Machine")]
class Machine { }

class ReadingAttributes
{
    public static void Main()
    {
        if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
        {
            Console.WriteLine("Person's got Serializable attribute");
        }
        else
        {
            Console.WriteLine("Person hasn't got Serializable attribute");
        }

        if (Attribute.IsDefined(typeof(Student), typeof(SerializableAttribute)))
        {
            Console.WriteLine("Student's got Serializable attribute");
        }
        else
        {
            Console.WriteLine("Student hasn't got Serializable attribute");
        }

        if (Attribute.IsDefined(typeof(Machine), typeof(SerializableAttribute)))
        {
            Console.WriteLine("Machine's got Serializable attribute");
        }
        else
        {
            Console.WriteLine("Machine hasn't got Serializable attribute");
        }

        if (Attribute.IsDefined(typeof(Machine), typeof(MachineryAttribute)))
        {
            Console.WriteLine("Machine's got Machinery attribute.");
        }

        try
        {
            ConditionalAttribute conditionalAttribute =
            (ConditionalAttribute)Attribute.GetCustomAttribute(
                typeof(ConditionalClass),
                typeof(ConditionalAttribute));

            string condition = conditionalAttribute.ConditionString;
            Console.WriteLine(condition);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
        }

        MachineryAttribute machineryaAttribute =
            (MachineryAttribute)Attribute.GetCustomAttribute(
                typeof(Machine),
                typeof(MachineryAttribute));

        string version = machineryaAttribute.Type;
        Console.WriteLine(version);
    }

    [Conditional("CONDITION1")]
    public class ConditionalClass : Attribute
    {
        [Conditional("CONDITION1"), Conditional("CONDITION2")]
        public static void MyMethod() { }
    }
}