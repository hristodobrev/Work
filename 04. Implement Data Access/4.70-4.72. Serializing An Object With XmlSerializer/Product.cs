using System;
using System.Xml.Serialization;

[Serializable]
public class Product
{
    [XmlAttribute]
    public int Id { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }
}