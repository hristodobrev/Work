using System;
using System.Xml;
using System.Xml.Schema;

class ValidatingXML
{
    static void Main()
    {
        ValidateXML();
    }

    static void ValidateXML()
    {
        string xsdPath = "person.xsd";
        string xmlPath = "person.xml";

        XmlReader reader = XmlReader.Create(xmlPath);
        XmlDocument document = new XmlDocument();
        document.Schemas.Add("", xsdPath);
        document.Load(reader);

        ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
        document.Validate(eventHandler);
    }

    static void ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        switch (e.Severity)
        {
            case XmlSeverityType.Error:
                Console.WriteLine("Error: {0}", e.Message);
                break;
            case XmlSeverityType.Warning:
                Console.WriteLine("Warning: {0}", e.Message);
                break;
        }
    }
}