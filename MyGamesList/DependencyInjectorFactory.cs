using MyGamesList.Abstractions;

namespace MyGamesList
{
    public class DependencyInjectorFactory
    {
        private ICommandMapper? commandMapper;
        private IArgumentProcessor? argumentProcessor;

        public IArgumentProcessor GetArgumentProcessor()
        {
            if (argumentProcessor == null)
            {
                commandMapper = GetCommandMapper();
                argumentProcessor = new ArgumentProcessor(commandMapper);
            }

            return argumentProcessor;
        }

        private ICommandMapper GetCommandMapper()
        {
            if (commandMapper == null)
            {
                List<ICommand> commands = new List<ICommand>
                {
                    new HelpCommand()
                };
                commandMapper = new CommandMapper(commands);
            }

            return commandMapper;
        }
    }
}
