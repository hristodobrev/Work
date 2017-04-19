using System;
using System.Globalization;
using System.Text.RegularExpressions;

class SearchingForStrings
{
    static void Main()
    {
        string value = "My Sample Value";
        int indexOfP = value.IndexOf("p");
        int lastIndexOfM = value.LastIndexOf("m");
        Console.WriteLine("Value: " + value);
        Console.WriteLine("Index of 'p' is: " + indexOfP);
        Console.WriteLine("Last index of 'm' is: " + lastIndexOfM);
        string sample = value.Substring(3, 6);
        Console.WriteLine(sample);

        string table = "<table>";
        if (table.StartsWith("<") && table.EndsWith(">"))
        {
            Console.WriteLine("Valid html element");
        }

        string pattern = "(Mr\\.? |Mrs\\.?| Miss |Ms\\.? )";
        string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels",
                         "Abraham Adams", "Ms. Nicole Norris" };
        foreach (string name in names)
        {
            Console.WriteLine(Regex.Replace(name, pattern, string.Empty));
        }

        double cost = 1234.56;
        Console.WriteLine(cost.ToString("C", new CultureInfo("bg-BG")));

        DateTime d = DateTime.Now;
        CultureInfo provider = new CultureInfo("en-US");
        Console.WriteLine(d.ToString("d", provider));
        Console.WriteLine(d.ToString("D", provider));
        Console.WriteLine(d.ToString("M", provider));
    }
}