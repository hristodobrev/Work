using System;
using System.Security.Cryptography;

class ExportingPublicKey
{
    static void Main()
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        string publicKeyXML = rsa.ToXmlString(false);
        string privateKeyXML = rsa.ToXmlString(true);

        Console.WriteLine("Public Key:");
        Console.WriteLine(publicKeyXML);
        Console.WriteLine();
        Console.WriteLine("Private Key:");
        Console.WriteLine(privateKeyXML);
    }
}