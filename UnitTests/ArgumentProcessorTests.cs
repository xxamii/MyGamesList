using MyGamesList;
using MyGamesList.Abstractions;

namespace UnitTests
{
    public class ArgumentProcessorTests
    {
        [Fact]
        public void ParseEmpty()
        {
            ICommandMapper mockedMapper = new MockedCommandMapper();
            ArgumentProcessor argumentProcessor = new ArgumentProcessor(mockedMapper);

            string result = argumentProcessor.ParseArgument("");

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ParseNonEmpty()
        {
            ICommandMapper mockedMapper = new MockedCommandMapper();
            ArgumentProcessor argumentProcessor = new ArgumentProcessor(mockedMapper);
            string value = "   MocKEd TesT  ";
            string expected = "mocked test";

            string result = argumentProcessor.ParseArgument(value);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParseNullValue()
        {
            ICommandMapper mockedMapper = new MockedCommandMapper();
            ArgumentProcessor argumentProcessor = new ArgumentProcessor(mockedMapper);

            string result = argumentProcessor.ParseArgument(null);

            Assert.Equal(string.Empty, result);
        }
    }
}