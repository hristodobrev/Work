using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Person
{
    public int Id { get; set; }

    public string Name { get; set; }

    [NonSerialized]
    private bool isDirty = false;
}

class UsingBinarySerialization
{
    static void Main()
    {
        Person p = new Person { Id = 1, Name = "John Doe" };

        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream("data.bin", FileMode.Create))
        {
            formatter.Serialize(stream, p);
        }

        using (Stream stream = new FileStream("data.bin", FileMode.Open))
        {
            Person dp = (Person)formatter.Deserialize(stream);
            Console.WriteLine(dp.Name);
        }
    }

    [OnSerializing()]
    internal void OnSerializingMethod(StreamingContext context)
    {
        Console.WriteLine("OnSerializing.");
    }

    [OnSerialized()]
    internal void OnSerializedMethod(StreamingContext context)
    {
        Console.WriteLine("OnSerialized.");
    }

    [OnDeserializing()]
    internal void OnDeserializingMethod(StreamingContext context)
    {
        Console.WriteLine("OnDeserializing.");
    }

    [OnDeserialized()]
    internal void OnDeserializedMethod(StreamingContext context)
    {
        Console.WriteLine("OnDeserialized.");
    }
}
