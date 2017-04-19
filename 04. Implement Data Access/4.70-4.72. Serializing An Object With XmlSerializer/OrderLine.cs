using System;
using System.Xml.Serialization;

[Serializable]
public class OrderLine
{
    [XmlAttribute]
    public int ID { get; set; }

    [XmlAttribute]
    public int Amount { get; set; }

    [XmlElement("OrderedProduct")]
    public Product Product { get; set; }
}