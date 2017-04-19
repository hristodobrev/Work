using System;
using System.Globalization;

class ParsingUsingConfigOptions
{
    static void Main()
    {
        CultureInfo english = new CultureInfo("En");
        CultureInfo dutch = new CultureInfo("Nl");

        string value = "€19,95";
        decimal d = decimal.Parse(value, NumberStyles.Currency, dutch);
        Console.WriteLine("{0:d}", d.ToString(english));

        DateTime date = DateTime.Parse("27/10/2016", CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        Console.WriteLine(date);

        int i = Convert.ToInt32(null);
        Console.WriteLine(i);

        double db = 23.15;
        int integer = Convert.ToInt32(db);
        Console.WriteLine(integer);
    }
}