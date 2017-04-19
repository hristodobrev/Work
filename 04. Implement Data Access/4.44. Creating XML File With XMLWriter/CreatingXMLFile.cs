using System;
using System.IO;
using System.Xml;

class CreatingXMLFile
{
    static void Main()
    {
        StringWriter stream = new StringWriter();

        using (XmlWriter writer = XmlWriter.Create(stream,
            new XmlWriterSettings() { Indent = true }))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("People");
            writer.WriteStartElement("Person");
            writer.WriteAttributeString("firstname", "John");
            writer.WriteAttributeString("lastname", "Doe");
            writer.WriteStartElement("ContactDetails");
            writer.WriteElementString("EmailAddress", "john@unknown.com");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();
        }

        Console.WriteLine(stream.ToString());
    }
}