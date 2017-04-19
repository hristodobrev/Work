using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
public class Order
{
    [XmlAttribute]
    public int ID { get; set; }

    [XmlIgnore]
    public bool IsDirty { get; set; }

    [XmlArray("Lines")]
    [XmlArrayItem("OrderLine")]
    public List<OrderLine> OrderLines { get; set; }
}