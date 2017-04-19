using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

class SerializingObjectWithXmlSerializer
{
    static void Main()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Order),
            new Type[] { typeof(VIPOrder) });
        string xml;
        using (StringWriter stringWriter = new StringWriter())
        {
            Order order = CreateOrder();
            serializer.Serialize(stringWriter, order);
            xml = stringWriter.ToString();
        }

        Console.WriteLine(xml);

        using (StringReader stringReader = new StringReader(xml))
        {
            Order o = (Order)serializer.Deserialize(stringReader);
        }
    }

    static Order CreateOrder()
    {
        Product p1 = new Product() { Id = 1, Description = "p2", Price = 9 };
        Product p2 = new Product() { Id = 2, Description = "p3", Price = 6 };

        Order order = new VIPOrder
        {
            ID = 4,
            Description = "Order for John Doe. Use the nice giftwrap",
            OrderLines = new List<OrderLine>
            {
                new OrderLine { ID = 5, Amount = 1, Product = p1 },
                new OrderLine { ID = 6, Amount = 10, Product = p2 }
            }
        };

        return order;
    }

    static void Serialize()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        string xml;
        using (StringWriter stringWriter = new StringWriter())
        {
            Person p = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 42
            };
            serializer.Serialize(stringWriter, p);
            xml = stringWriter.ToString();
        }

        Console.WriteLine(xml);

        using (StringReader stringReader = new StringReader(xml))
        {
            Person p = (Person)serializer.Deserialize(stringReader);
            Console.WriteLine("{0} {1} is {2} year(s) old.", p.FirstName, p.LastName, p.Age);
        }
    }
}