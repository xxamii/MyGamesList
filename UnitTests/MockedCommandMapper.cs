using MyGamesList.Abstractions;

namespace UnitTests
{
    internal class MockedCommandMapper : ICommandMapper
    {
        public ICommand GetCommand(string argument)
        {
            return new MockedCommand();
        }
    }
}
