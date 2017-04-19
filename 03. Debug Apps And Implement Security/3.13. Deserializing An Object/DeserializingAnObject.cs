using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

class DeserializingAnObject
{
    static void Main()
    {
        var serializer = new JavaScriptSerializer();
        var obj = new { a = 5, b = "test" };
        var json = serializer.Serialize(obj);
        Console.WriteLine(json);
        var result = serializer.Deserialize<Dictionary<string, object>>(json);
        foreach (var item in result)
        {
            Console.WriteLine(item.Key + " -> " + result[item.Key]);
        }
    }
}