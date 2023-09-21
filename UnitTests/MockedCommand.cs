using MyGamesList.Abstractions;

namespace UnitTests
{
    internal class MockedCommand : ICommand
    {
        public string CommandName => "mock";

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
