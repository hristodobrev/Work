using System;
using HQC.Driver;
using HQC.Exceptions;
using HQC.IO;
using HQC.Models;
using HQC.Session;
using HQC.Services;

namespace HQC.Core.CommandExecuter.Commands
{
    public class ProfileCommand : Command
    {
        public ProfileCommand(IDatabase database, ISessionManager sessionManager, ICryptoService cryptoService, IWriter writer, IReader reader)
            : base(database, sessionManager, cryptoService, writer, reader)
        {
        }

        public override string Execute()
        {
            this.Authorize();

            IUser user = (IUser)this.sessionManager.GetSession("user");

            string result = "Hello, " + user.Username + Environment.NewLine;
            result += "Your email is " + user.Email;

            return result;
        }
    }
}
