using HQC.Driver;
using HQC.Exceptions;
using HQC.IO;
using HQC.Models;
using HQC.Services;
using HQC.Session;
using System;
using System.Security.Cryptography;

namespace HQC.Core.CommandExecuter.Commands
{
    public class LoginCommand : Command
    {
        public LoginCommand(string username, string password, IDatabase database, ISessionManager sessionManager, ICryptoService cryptoService, IWriter writer, IReader reader)
            : base(database, sessionManager, cryptoService, writer, reader)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public override string Execute()
        {
            IUser user = this.database.GetUserByUsername(this.Username);

            if (this.sessionManager.SessionKeyExists("user"))
            {
                throw new LoginException("User is already logged");
            }

            if (!this.database.UserExists(this.Username))
            {
                throw new LoginException("User with this username does not exist");
            }

            string passwordHash = user.Password;
            byte[] hashBytes = Convert.FromBase64String(passwordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(this.Password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i+16] != hash[i])
                {
                    throw new LoginException("Invalid password");
                }
            }

            this.sessionManager.AddSession("user", user);

            return "Successfully logged in.";
        }
    }
}
