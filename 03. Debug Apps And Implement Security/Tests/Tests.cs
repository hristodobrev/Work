namespace Tests
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Linq;
    using System.Security.Permissions;
    using System.Security;
    using System.Runtime.InteropServices;

    public class Tests
    {
        [FileIOPermission(SecurityAction.Demand, AllLocalFiles = FileIOPermissionAccess.Read)]
        public static void ReadFromFileDeclarativeCAS()
        {
            using (StreamReader sr = new StreamReader("file.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        [FileIOPermission(SecurityAction.Demand, AllLocalFiles = FileIOPermissionAccess.Write)]
        public static void WriteToFileDeclarativeCAS(string text)
        {
            using (StreamWriter sr = new StreamWriter("file.txt", true))
            {
                sr.WriteLine(text);
            }
        }

        static void Main()
        {
            WriteToFileDeclarativeCAS("Some text");
            WriteToFileDeclarativeCAS("Some other text");
            WriteToFileDeclarativeCAS("Yet another text");
            ReadFromFileDeclarativeCAS();
            using (SecureString ss = new SecureString())
            {
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }

                ss.MakeReadOnly();

                IntPtr unmanagedString = IntPtr.Zero;
                try
                {
                    unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(ss);
                    Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
            }

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            string publicKey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);

            UnicodeEncoding byteConverter = new UnicodeEncoding();

            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKey);
                encryptedData = RSA.Encrypt(byteConverter.GetBytes("Some data!"), false);
            }

            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKey);
                decryptedData = RSA.Decrypt(encryptedData, false);
            }

            Console.WriteLine(byteConverter.GetString(encryptedData));
            Console.WriteLine(byteConverter.GetString(decryptedData));

            Console.WriteLine(byteConverter.GetString(Encrypt(new AesCryptoServiceProvider(), "Some data!")));
        }

        private static byte[] Encrypt(SymmetricAlgorithm sa, string data)
        {
            ICryptoTransform encryptor = sa.CreateEncryptor();

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(data);
                    }

                    return ms.ToArray();
                }
            }
        }
    }
}
