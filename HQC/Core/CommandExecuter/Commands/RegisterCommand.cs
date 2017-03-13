using HQC.Driver;
using HQC.Exceptions;
using HQC.IO;
using HQC.Models;
using HQC.Services;
using HQC.Session;

namespace HQC.Core.CommandExecuter.Commands
{
    public class RegisterCommand : Command
    {
        public RegisterCommand(string username, string password, string email, IDatabase database, ISessionManager sessionManager, ICryptoService cryptoService, IWriter writer, IReader reader)
            : base(database, sessionManager, cryptoService, writer, reader)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public override string Execute()
        {
            if (this.sessionManager.SessionKeyExists("user"))
            {
                throw new LoginException("You must logout first");
            }

            if (database.UserExists(this.Username))
            {
                throw new RegisterException("User with this username already exists");
            }

            IUser user = new User(this.database.GetNextId(), this.Username, this.cryptoService.PasswordHash(this.Password), this.Email);

            this.database.CreateUser(user);

            return "Registered successfully.";
        }
    }
}
