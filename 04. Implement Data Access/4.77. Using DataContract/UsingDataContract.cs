using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

[DataContract]
public class PersonDataContract
{
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public string Name { get; set; }

    private bool isDirty = false;
}

class UsingDataContract
{
    static void Main()
    {
        UsingXmlSerializer();
        UsingJsonSerializer();
    }

    static void UsingJsonSerializer()
    {
        PersonDataContract p = new PersonDataContract
        {
            Id = 1,
            Name = "John Doe"
        };

        using (MemoryStream stream = new MemoryStream())
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PersonDataContract));
            ser.WriteObject(stream, p);

            stream.Position = 0;
            StreamReader streamReader = new StreamReader(stream);
            Console.WriteLine(streamReader.ReadToEnd());
            
            stream.Position = 0;
            PersonDataContract result = (PersonDataContract)ser.ReadObject(stream);
        }
    }

    static void UsingXmlSerializer()
    {
        PersonDataContract p = new PersonDataContract
        {
            Id = 1,
            Name = "John Doe"
        };

        using (Stream stream = new FileStream("data.xml", FileMode.Create))
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(PersonDataContract));
            ser.WriteObject(stream, p);
        }

        using (Stream stream = new FileStream("data.xml", FileMode.Open))
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(PersonDataContract));
            PersonDataContract result = (PersonDataContract)ser.ReadObject(stream);
            Console.WriteLine(result.Name);
        }
    }
}