using MyGamesList;
using MyGamesList.Abstractions;

namespace UnitTests
{
    public class CommandMapperTests
    {
        [Fact]
        public void CommandExists()
        {
            ICommand command = new MockedCommand();
            List<ICommand> commands = new List<ICommand> { command };
            ICommandMapper commandMapper = new CommandMapper(commands);

            ICommand result = commandMapper.GetCommand("mock");

            Assert.Equal(command, result);
        }

        [Fact]
        public void CommandDoesNotExist()
        {
            List<ICommand> commands = new List<ICommand>();
            ICommandMapper commandMapper = new CommandMapper(commands);

            ICommand result = commandMapper.GetCommand("");

            Assert.IsType<NotFoundCommand>(result);
        }
    }
}
