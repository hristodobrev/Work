using HQC.Driver;
using HQC.Exceptions;
using HQC.IO;
using HQC.Models;
using HQC.Services;
using HQC.Session;
namespace HQC.Core.CommandExecuter
{
    public abstract class Command : ICommand
    {
        protected IDatabase database;
        protected ISessionManager sessionManager;
        protected ICryptoService cryptoService;
        protected IWriter writer;
        protected IReader reader;

        public Command(IDatabase database, ISessionManager sessionManager, ICryptoService cryptoService, IWriter writer, IReader reader)
        {
            this.database = database;
            this.sessionManager = sessionManager;
            this.cryptoService = cryptoService;
            this.writer = writer;
            this.reader = reader;
        }

        public abstract string Execute();

        public void Authorize(UserRole role = UserRole.User)
        {
            if (role == UserRole.Guest)
            {
                return;
            }

            if (!this.sessionManager.SessionKeyExists("user"))
            {
                throw new AuthorizeException("You must be logged in to do this operation");
            }

            IUser user = (IUser)this.sessionManager.GetSession("user");
            if (role == UserRole.Admin && (user.Role != UserRole.Admin))
            {
                throw new AuthorizeException("You have no permissions to execute this operation");
            }
        }
    }
}
