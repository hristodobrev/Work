using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

[Serializable]
public class PersonComplex : ISerializable
{
    public int Id { get; set; }

    public string Name { get; set; }

    private bool isDirty = false;

    public PersonComplex() { }

    protected PersonComplex(SerializationInfo info, StreamingContext context)
    {
        this.Id = info.GetInt32("Value1");
        this.Name = info.GetString("Value2");
        this.isDirty = info.GetBoolean("Value3");
    }

    [SecurityPermission(SecurityAction.Demand,
        SerializationFormatter = true)]
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Value1", this.Id);
        info.AddValue("Value2", this.Name);
        info.AddValue("Value3", this.isDirty);
    }
}

class ImplementingISerializable
{
    static void Main()
    {

    }
}