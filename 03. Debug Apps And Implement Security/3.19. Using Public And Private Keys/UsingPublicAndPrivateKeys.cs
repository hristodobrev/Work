using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class UsingPublicAndPrivateKeys
{
    static void Main()
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        string publicKeyXML = rsa.ToXmlString(false);
        string privateKeyXML = rsa.ToXmlString(true);

        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        byte[] dataToEncrypt = ByteConverter.GetBytes("My Secret Data!");

        byte[] encryptedData;
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        {
            RSA.FromXmlString(publicKeyXML);
            encryptedData = RSA.Encrypt(dataToEncrypt, false);
        }

        byte[] decryptedData;
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        {
            RSA.FromXmlString(privateKeyXML);
            decryptedData = RSA.Decrypt(encryptedData, false);
        }

        string encryptedString = ByteConverter.GetString(encryptedData);
        string decryptedString = ByteConverter.GetString(decryptedData);
        Console.WriteLine(encryptedString);
        Console.WriteLine(decryptedString);

        using (TextWriter writer = new StreamWriter("encryptedData.txt"))
        {
            writer.WriteLine(encryptedString);
        }

        using (TextReader reader = new StreamReader("encryptedData.txt"))
        {
            string encryptedStr = reader.ReadLine();
            //Console.WriteLine(encryptedStr);
            //byte[] bytestToEnc = ByteConverter.GetBytes(encryptedStr);
            //byte[] encBytes;
            //using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            //{
            //    RSA.FromXmlString(publicKeyXML);
            //    encBytes = RSA.Encrypt(bytestToEnc, false);
            //}
            byte[] encBytes = ByteConverter.GetBytes(encryptedStr);
            //Console.WriteLine(string.Join(", ", encBytes));
            //Console.WriteLine(string.Join(", ", encryptedData));
            byte[] decBytes;

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKeyXML);
                //decBytes = RSA.Decrypt(encBytes, false);
            }

            //Console.WriteLine(ByteConverter.GetString(decBytes));
        }
    }
}