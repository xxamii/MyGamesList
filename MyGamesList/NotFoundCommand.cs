using MyGamesList.Abstractions;

namespace MyGamesList
{
    internal class NotFoundCommand : ICommand
    {
        public string CommandName { get; }

        public NotFoundCommand(string commandName)
        {
            CommandName = commandName;
        }

        public void Execute()
        {
            Console.WriteLine($"Page {CommandName} was not found, try \'help\' to see the list of available pages");
        }
    }
}
