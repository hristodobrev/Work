using System;
using System.Security.Cryptography;
namespace HQC.Services
{
    public class CryptoService : ICryptoService
    {
        public string PasswordHash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public bool ValidatePassword(string password, string hash)
        {
            throw new System.NotImplementedException();
        }
    }
}
