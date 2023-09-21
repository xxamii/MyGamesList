using MyGamesList.Abstractions;

namespace MyGamesList
{
    internal class CommandMapper : ICommandMapper
    {
        private readonly List<ICommand> _commands;

        public CommandMapper(List<ICommand> commands)
        {
            _commands = commands;
        }

        public ICommand GetCommand(string argument)
        {
            ICommand defaultCommand = new NotFoundCommand(argument);
            ICommand command = _commands.FirstOrDefault(a => a.CommandName == argument, defaultCommand);
            return command;
        }
    }
}
