using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

class SigningAndVerifyingData
{
    static void Main()
    {
        SignAndVerify();
    }

    static void SignAndVerify()
    {
        string textToSign = "Test paragraph";
        byte[] signature = Sign(textToSign, "cn=WouterDeKort");

        // signature[0] = 0; // Uncomment this to make the verification step fail
        Console.WriteLine(Verify(textToSign, signature));
    }

    static byte[] Sign(string text, string certSubject)
    {
        X509Certificate2 cert = GetCertificate();
        var csp = (RSACryptoServiceProvider)cert.PrivateKey;
        byte[] hash = HashData(text);

        return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
    }

    static bool Verify(string text, byte[] signature)
    {
        X509Certificate2 cert = GetCertificate();
        var csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
        byte[] hash = HashData(text);
        return csp.VerifyHash(hash,
            CryptoConfig.MapNameToOID("SHA1"),
            signature);
    }

    static byte[] HashData(string text)
    {
        HashAlgorithm hashAlgorithm = new SHA1Managed();
        UnicodeEncoding encoding = new UnicodeEncoding();
        byte[] data = encoding.GetBytes(text);
        byte[] hash = hashAlgorithm.ComputeHash(data);

        return hash;
    }

    static X509Certificate2 GetCertificate()
    {
        X509Store my = new X509Store("testCertStore",
            StoreLocation.CurrentUser);
        my.Open(OpenFlags.ReadOnly);

        var certificate = my.Certificates[0];

        return certificate;
    }
}