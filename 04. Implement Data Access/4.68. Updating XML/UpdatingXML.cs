using System;
using System.Linq;
using System.Xml.Linq;

class UpdatingXML
{
    static void Main()
    {
        string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<people>
  <person firstname=""john"" lastname=""doe"">
    <contactdetails>
      <emailaddress>john@unknown.com</emailaddress>
    </contactdetails>
  </person>
  <person firstname=""jane"" lastname=""doe"">
    <contactdetails>
      <emailaddress>jane@unknown.com</emailaddress>
      <phonenumber>001122334455</phonenumber>
    </contactdetails>
  </person>
</people>";

        XElement root = XElement.Parse(xml);

        XElement newTree = new XElement("people",
            from p in root.Descendants("person")
            let name = (string)p.Attribute("firstname") + (string)p.Attribute("lastname")
            let contactDetails = p.Element("contactdetails")
            select new XElement("person",
                new XAttribute("ismale", name.Contains("john")),
                p.Attributes(),
                new XElement("contactdetails",
                    contactDetails.Element("emailaddress"),
                    contactDetails.Element("phonenumber")
                    ?? new XElement("phonenumber", "001122334455")
                )));

        Console.WriteLine(root.ToString());
        Console.WriteLine("=======================");
        Console.WriteLine(newTree.ToString());
    }

    static void UpdateXml(string xml)
    {
        XElement root = XElement.Parse(xml);

        foreach (XElement p in root.Descendants("person"))
        {
            string name = (string)p.Attribute("firstname") + (string)p.Attribute("lastname");
            p.Add(new XAttribute("ismale", name.Contains("john")));
            XElement contactDetails = p.Element("contactdetails");
            if (!contactDetails.Descendants("phonenumber").Any())
            {
                contactDetails.Add(new XElement("phonenumber", "001122334455"));
            }
        }

        Console.WriteLine(root.ToString());
    }
}