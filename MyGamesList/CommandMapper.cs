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
            ICommand result = _commands.FirstOrDefault(a => a.CommandName == argument);
            ICommand command = result ?? new NotFoundCommand(argument);
            return command;
        }
    }
}
