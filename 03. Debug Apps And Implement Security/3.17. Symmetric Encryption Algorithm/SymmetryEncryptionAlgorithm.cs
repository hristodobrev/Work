using System;
using System.Linq;
using System.IO;
using System.Security.Cryptography;

class SymmetryEncryptionAlgorithm
{
    static void Main()
    {
        string original = "My secret data!";

        using (SymmetricAlgorithm symmetricAlgorithm = new AesManaged())
        {
            byte[] encrypted = Encrypt(symmetricAlgorithm, original);
            string roundtrip = Decrypt(symmetricAlgorithm, encrypted);

            Console.WriteLine("Original: {0}", original);
            Console.WriteLine("Round Trip: {0}", roundtrip);
        }
    }

    static byte[] EncryptCopy(SymmetricAlgorithm symmetricAlgorithm, string plainText)
    {
        ICryptoTransform encryptor = symmetricAlgorithm.CreateEncryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);

        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }

                return msEncrypt.ToArray();
            }
        }
    }

    static string DecryptCopy(SymmetricAlgorithm symmetricAlgorithm, byte[] chipherText)
    {
        ICryptoTransform decryptor = symmetricAlgorithm.CreateDecryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);

        using (MemoryStream msDecryptor = new MemoryStream(chipherText))
        {
            using (CryptoStream csDecryptor = new CryptoStream(msDecryptor, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader srDecryptor = new StreamReader(csDecryptor))
                {
                    return srDecryptor.ReadToEnd();
                }
            }
        }
    }

    static byte[] Encrypt(SymmetricAlgorithm aesAlg, string plainText)
    {
        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (CryptoStream csEncrypt = 
                new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }

                return msEncrypt.ToArray();
            }
        }
    }

    static string Decrypt(SymmetricAlgorithm aesAlg, byte[] cipherText)
    {
        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using (MemoryStream msDecrypt = new MemoryStream(cipherText))
        {
            using (CryptoStream csDecrypt =
                new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}