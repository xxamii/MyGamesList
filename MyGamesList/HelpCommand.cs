using MyGamesList.Abstractions;

namespace MyGamesList
{
    internal class HelpCommand : ICommand
    {
        public string CommandName => CommandNames.HelpCommandName;

        public void Execute()
        {
            Console.WriteLine("help - Lists all available commands");
        }
    }
}
