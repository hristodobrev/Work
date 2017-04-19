namespace HQC.Core.CommandExecuter
{
    public interface ICommandExecuter
    {
        ICommand CreateCommand(string commandName, string[] args);
    }
}
