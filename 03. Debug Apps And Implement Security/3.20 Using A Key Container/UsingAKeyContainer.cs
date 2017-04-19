using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

class UsingAKeyContainer
{
    static void Main()
    {
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        string secretMessage = "SecretMessage";
        byte[] dataToEncrypt = ByteConverter.GetBytes(secretMessage);

        string containerName = "SecretContainer";
        CspParameters csp = new CspParameters()
        {
            KeyContainerName = containerName
        };

        string anotherContainerName = "AnotherContainer";
        CspParameters csp1 = new CspParameters()
        {
            KeyContainerName = anotherContainerName
        };

        byte[] encryptedData;
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp))
        {
            encryptedData = RSA.Encrypt(dataToEncrypt, false);
        }

        byte[] decryptedData;
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp))
        {
            decryptedData = RSA.Decrypt(encryptedData, false);
        }

        byte[] anotherEncryptedData;
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp1))
        {
            anotherEncryptedData = RSA.Encrypt(decryptedData, false);
        }

        byte[] anotherDecryptedData;
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp1))
        {
            anotherDecryptedData = RSA.Decrypt(anotherEncryptedData, false);
        }

        Console.WriteLine(string.Join("", anotherDecryptedData.Select(c => (char)c)));

        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        string publicKey = rsa.ToXmlString(false);
        string privateKey = rsa.ToXmlString(true);

        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        {
            RSA.FromXmlString(publicKey);
            encryptedData = RSA.Encrypt(dataToEncrypt, false);
        }

        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        {
            RSA.FromXmlString(privateKey);
            decryptedData = RSA.Decrypt(encryptedData, false);
        }

        Console.WriteLine(ByteConverter.GetString(decryptedData));
    }
}