using System;
using System.Text.RegularExpressions;

class ValidateZipCode
{
    static void Main()
    {
        Console.WriteLine(ValidateZipCodeManually("1234AB"));
        Console.WriteLine(ValidateZipCodeManually("1234 AB"));
        Console.WriteLine(ValidateZipCodeRegEx("1001 AB"));
        Console.WriteLine(ValidateZipCodeRegEx("1001 ACB"));

        Console.WriteLine(ReplaceExcessiveWhiteSpaces(
            "This         is            some       text       " +
            "     which is           so               stretched."));
    }

    static bool ValidateZipCodeManually(string zipCode)
    {
        // Valid zipcodes: 1234AB | 1234 AB | 1001 AB

        if (zipCode.Length < 6)
        {
            return false;
        }

        string numberPart = zipCode.Substring(0, 4);
        int number;
        if (!int.TryParse(numberPart, out number))
        {
            return false;
        }

        string characterPart = zipCode.Substring(4);
        if (characterPart.Trim().Length != 2)
        {
            return false;
        }
        if (characterPart.Length == 3 && characterPart.Trim().Length != 2)
        {
            return false;
        }

        return true;
    }

    static bool ValidateZipCodeRegEx(string zipCode)
    {
        Match match = Regex.Match(zipCode, @"^[1-9][0-9]{3}\s?[A-Za-z]{2}$", RegexOptions.IgnoreCase);

        return match.Success;
    }

    static string ReplaceExcessiveWhiteSpaces(string text)
    {
        RegexOptions options = RegexOptions.None;
        Regex regex = new Regex(@"[ ]{2,}", options);

        string result = regex.Replace(text, " ");

        return result;
    }
}