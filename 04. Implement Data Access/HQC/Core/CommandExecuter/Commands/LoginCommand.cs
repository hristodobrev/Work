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

            if (!this.cryptoService.ValidatePassword(this.Password, user.Password))
            {
                throw new LoginException("Invalid password");
            }

            this.sessionManager.AddSession("user", user);

            return "Successfully logged in.";
        }
    }
}
