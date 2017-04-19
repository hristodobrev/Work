using HQC.Core;
using HQC.Core.CommandExecuter;
using HQC.Driver;
using HQC.IO;
using HQC.Services;
using HQC.Session;

namespace HQC
{
    class Program
    {
        static void Main()
        {
            ISessionManager sessionManager = new SessionManager();
            IDatabase database = new UsersDatabase();
            ICryptoService cryptoService = new CryptoService();
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            ICommandExecuter commandExecuter = new CommandExecuter(database, sessionManager, cryptoService, writer, reader);

            Application app = new Application(sessionManager, commandExecuter, writer, reader);

            app.Start();
        }
    }
}
