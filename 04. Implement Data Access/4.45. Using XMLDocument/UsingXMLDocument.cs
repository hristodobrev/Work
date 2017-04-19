using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;

class UsingXMLDocument
{
    static void Main()
    {
        UsingXPathQuery();
    }

    static void UsingXPathQuery()
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(GetXml());

        XPathNavigator nav = doc.CreateNavigator();
        string query = @"/People/Person[@firstName='John']";
        XPathNodeIterator iterator = nav.Select(query);

        Console.WriteLine(iterator.Count);

        while (iterator.MoveNext())
        {
            string firstName = iterator.Current.GetAttribute("firstName", "");
            string lastName = iterator.Current.GetAttribute("lastName", "");
            Console.WriteLine("Name: {0} {1}", firstName, lastName);
        }
    }

    static void XMLDocument()
    {
        XmlDocument doc = new XmlDocument();

        doc.LoadXml(GetXml());
        XmlNodeList nodes = doc.GetElementsByTagName("Person");
        foreach (XmlNode node in nodes)
        {
            string firstName = node.Attributes["firstName"].Value;
            string lastName = node.Attributes["lastName"].Value;
            Console.WriteLine("Name: {0} {1}", firstName, lastName);
        }

        XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "Person", "");

        XmlAttribute firstNameAttribute = doc.CreateAttribute("firstName");
        firstNameAttribute.Value = "Hristo";

        XmlAttribute lastNameAttribute = doc.CreateAttribute("lastName");
        lastNameAttribute.Value = "Dobrev";

        newNode.Attributes.Append(firstNameAttribute);
        newNode.Attributes.Append(lastNameAttribute);

        doc.DocumentElement.AppendChild(newNode);
        Console.WriteLine("Modified xml...");
        doc.Save(Console.Out);
    }

    static string GetXml()
    {
        StringWriter stream = new StringWriter();

        using (XmlWriter writer = XmlWriter.Create(stream,
            new XmlWriterSettings() { Indent = true }))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("People");
            writer.WriteStartElement("Person");
            writer.WriteAttributeString("firstName", "John");
            writer.WriteAttributeString("lastName", "Doe");
            writer.WriteStartElement("ContactDetails");
            writer.WriteElementString("EmailAddress", "john@unknown.com");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();
        }

        return stream.ToString();
    }
}