using System;
using System.Collections.Generic;
using HQC.Driver;
using HQC.IO;
using HQC.Models;
using HQC.Session;
using HQC.Services;

namespace HQC.Core.CommandExecuter.Commands
{
    public class ListUsersCommand : Command
    {
        public ListUsersCommand(IDatabase database, ISessionManager sessionManager, ICryptoService cryptoService, IWriter writer, IReader reader) :
            base(database, sessionManager, cryptoService, writer, reader)
        {

        }
        
        public override string Execute()
        {
            this.Authorize(UserRole.Admin);

            string result = "";

            foreach (IUser user in this.database.GetAllUsers())
            {
                result += user.Username + Environment.NewLine;
            }

            return result;
        }
    }
}
