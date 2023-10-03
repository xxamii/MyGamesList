using MyGamesList.Abstractions;

namespace MyGamesList
{
    public static class DependencyInjectorFactory
    {
        private static ICommandMapper? commandMapper;
        private static IArgumentProcessor? argumentProcessor;

        public static IArgumentProcessor GetArgumentProcessor()
        {
            if (argumentProcessor == null)
            {
                commandMapper = GetCommandMapper();
                argumentProcessor = new ArgumentProcessor(commandMapper);
            }

            return argumentProcessor;
        }

        private static ICommandMapper GetCommandMapper()
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
