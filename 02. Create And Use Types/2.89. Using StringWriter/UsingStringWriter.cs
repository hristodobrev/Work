using System;
using System.Xml;
using System.IO;
using System.Globalization;

class UsingStringWriter
{
    static void Main()
    {
        var stringWriter = new StringWriter();
        using (XmlWriter writer = XmlWriter.Create(stringWriter))
        {
            writer.WriteStartElement("book");
            writer.WriteElementString("price", "19.95");
            writer.WriteEndElement();
            writer.Flush();
        }

        string xml = stringWriter.ToString();
        Console.WriteLine(xml);

        var stringReader = new StringReader(xml);
        using (XmlReader reader = XmlReader.Create(stringReader))
        {
            reader.ReadToFollowing("price");
            decimal price = decimal.Parse(reader.ReadInnerXml(),
                new CultureInfo("en-US"));
        }
    }
}