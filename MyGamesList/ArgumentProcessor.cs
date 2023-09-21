using MyGamesList.Abstractions;

namespace MyGamesList
{
    internal class ArgumentProcessor : IArgumentProcessor
    {
        private readonly ICommandMapper _commandMapper;

        public ArgumentProcessor(ICommandMapper commandMapper)
        {
            _commandMapper = commandMapper;
        }

        public void Process(string argument)
        {
            string parsedArgument = ParseArgument(argument);
            ICommand command = _commandMapper.GetCommand(parsedArgument);
            command.Execute();
        }

        public string ParseArgument(string argument)
        {
            if (argument == null)
                return string.Empty;

            return argument.ToLower().Trim();
        }
    }
}
