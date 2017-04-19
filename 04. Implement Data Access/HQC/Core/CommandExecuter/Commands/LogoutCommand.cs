using HQC.Driver;
using HQC.Exceptions;
using HQC.IO;
using HQC.Models;
using HQC.Services;
using HQC.Session;

namespace HQC.Core.CommandExecuter.Commands
{
    public class LogoutCommand : Command
    {
        public LogoutCommand(IDatabase database, ISessionManager sessionManager, ICryptoService cryptoService, IWriter writer, IReader reader)
            : base(database, sessionManager, cryptoService, writer, reader)
        {
        }

        public override string Execute()
        {
            this.sessionManager.DeleteSession("user");

            return "Logged out successfully.";
        }
    }
}
