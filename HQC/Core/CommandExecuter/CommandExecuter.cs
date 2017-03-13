using System;
using System.Collections.Generic;
using System.Linq;
using HQC.Driver;
using HQC.IO;
using HQC.Session;
using HQC.Services;

namespace HQC.Core.CommandExecuter
{
    public class CommandExecuter : ICommandExecuter
    {
        private IDatabase database;
        private ISessionManager sessionManager;
        private ICryptoService cryptoService;
        private IWriter writer;
        private IReader reader;

        public CommandExecuter(IDatabase database, ISessionManager sessionManager, ICryptoService cryptoService, IWriter writer, IReader reader)
        {
            this.database = database;
            this.sessionManager = sessionManager;
            this.writer = writer;
            this.reader = reader;
            this.cryptoService = cryptoService;
        }

        public ICommand CreateCommand(string commandName, string[] args)
        {
            string namespaceName = "HQC.Core.CommandExecuter.Commands";
            List<object> fullArgs = new List<object>();
            foreach (var arg in args)
            {
                fullArgs.Add(arg);
            }
            fullArgs.Add(this.database);
            fullArgs.Add(this.sessionManager);
            fullArgs.Add(this.cryptoService);
            fullArgs.Add(this.writer);
            fullArgs.Add(this.reader);

            Type type = Type.GetType(namespaceName + "." + CreateClassName(commandName));

            if (type == null)
            {
                throw new InvalidOperationException("Invalid Command");
            }

            return (ICommand)Activator.CreateInstance(type, fullArgs.ToArray());
        }

        private string CreateClassName(string className)
        {
            string firstLetter = className[0].ToString().ToUpper();

            return firstLetter + className.Substring(1) + "Command";
        }
    }
}
