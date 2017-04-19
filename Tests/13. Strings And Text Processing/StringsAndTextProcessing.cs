using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

class StringsAndTextProcessing
{
    static void Main()
    {
        string quote = "The main intent of the \"Intro C#\"" +
  " book is to introduce the C# programming to newbies.";
        string keyword = "C#";
        int index = quote.IndexOf(keyword);

        while (index != -1)
        {
            Console.WriteLine("{0} found at index: {1}", keyword, index);
            index = quote.IndexOf(keyword, index + 1);
        }

        string text = "aaaaa";
        Console.WriteLine(text.Replace("aa", "bb"));

        string doc = "Smith's number: 0898880022\nFranky can be " +
  " found at 0888445566.\nSteven’ mobile number: 0887654321";

        Regex reg = new Regex("(08)[0-9]{8}");
        string replacedDoc = reg.Replace(doc, "$1********");
        Console.WriteLine(replacedDoc);
        Console.WriteLine(Regex.Replace(doc, "(08)([0-9]{8})", "$2$1"));

        //string nums = "Numbers: ";
        //for (int i = 1; i <= 50000; i++)
        //{
        //    nums += i;
        //}

        StringBuilder sb = new StringBuilder("Some Text");
        sb.Remove(4, 1);
        Console.WriteLine(sb);

        string dateText = "01.12.2016";
        string format = "dd.MM.yyyy";
        DateTime parsedDate = DateTime.ParseExact(dateText, format, CultureInfo.InvariantCulture);
        Console.WriteLine("{0:dd-MM-yyyy}", parsedDate);
        
        Console.WriteLine();
        Console.WriteLine(AreCorrectBrackets("(a + (b)(a - b))"));

        string someText = "Наков";
        WriteHexText(someText);

        WriteHexText(CipherText());
    }

    static void WriteHexText(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write("\\u{0:x4}", (int)text[i]);
        }
        Console.WriteLine();
    }

    static string CipherText()
    {
        string text = "Nakov";
        StringBuilder cipheredText = new StringBuilder();
        string cipher = "ab";
        for (int i = 0; i < text.Length; i++)
        {
            cipheredText.Append((char)(text[i] ^ cipher[i % cipher.Length]));
        }

        return cipheredText.ToString();
    }

    static bool AreCorrectBrackets(string expression)
    {
        int bracketsCount = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
                bracketsCount++;
            else if (expression[i] == ')')
                bracketsCount--;

            if (bracketsCount < 0)
            {
                return false;
            }
        }

        if (bracketsCount != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}