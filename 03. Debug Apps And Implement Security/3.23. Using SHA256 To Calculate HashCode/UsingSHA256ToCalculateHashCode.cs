using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

class UsingSHA256ToCalculateHashCode
{
    static void Main()
    {
        UnicodeEncoding byteConverter = new UnicodeEncoding();
        SHA256 sha256 = SHA256.Create();

        string data = "A paragrapgh of text.";
        byte[] hashA = sha256.ComputeHash(byteConverter.GetBytes(data));

        data = "A paragrapgh of changed text.";
        byte[] hashB = sha256.ComputeHash(byteConverter.GetBytes(data));

        data = "A paragrapgh of text.";
        byte[] hashC = sha256.ComputeHash(byteConverter.GetBytes(data));

        Console.WriteLine(hashA.SequenceEqual(hashB));
        Console.WriteLine(hashA.SequenceEqual(hashC));
    }
}