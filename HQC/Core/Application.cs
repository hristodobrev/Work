using System;
using System.Linq;
using HQC.Core.CommandExecuter;
using HQC.Exceptions;
using HQC.IO;
using HQC.Session;

namespace HQC.Core
{
    public class Application
    {
        private ISessionManager sessionManager;
        private ICommandExecuter commandExecuter;
        private IWriter writer;
        private IReader reader;

        public Application(ISessionManager sessionManager, ICommandExecuter commandExecuter, IWriter writer, IReader reader)
        {
            this.sessionManager = sessionManager;
            this.commandExecuter = commandExecuter;
            this.writer = writer;
            this.reader = reader;
        }

        public void Start()
        {
            string line = reader.ReadLine();

            while (line.ToLower() != "exit")
            {
                try
                {
                    string[] args = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string commandName = args[0];
                    args = args.Skip(1).ToArray();

                    ICommand command = this.commandExecuter.CreateCommand(commandName, args);
                    string result = command.Execute();

                    writer.WriteLine(result);
                }
                catch (AuthorizeException exception)
                {
                    writer.WriteLine(exception.Message);
                }
                catch (LoginException exception)
                {
                    writer.WriteLine(exception.Message);
                }
                catch (RegisterException exception)
                {
                    writer.WriteLine(exception.Message);
                }
                catch (SessionException exception)
                {
                    writer.WriteLine(exception.Message);
                }
                catch (InvalidOperationException exception)
                {
                    writer.WriteLine(exception.Message);
                }
                //catch (Exception exception)
                //{
                //    writer.WriteLine(exception.Message);
                //}

                line = reader.ReadLine();
            }
        }
    }
}
