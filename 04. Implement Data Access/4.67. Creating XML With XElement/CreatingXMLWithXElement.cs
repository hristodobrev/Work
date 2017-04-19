using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

class CreatingXMLWithXElement
{
    static void Main()
    {
        XElement root = new XElement("Root",
            new List<XElement>
            {
                new XElement("Child1", new List<XElement>
                {
                    new XElement("SubChild1.1"),
                    new XElement("SubChild1.2"),
                    new XElement("SubChild1.3")
                },
                new XAttribute("SubChildAttribute", 13)),
                new XElement("Child2"),
                new XElement("Child3")
            },
            new XAttribute("MyAttribute", 42));
        root.Save("test.xml");
    }
}