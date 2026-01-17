using Shell.Domain.Abstracts;
using Shell.Domain.Commands;
using Shell.Output;

namespace Shell.Tests.Presentation
{
    public class OutputWriterTests
    {
        private readonly ConsoleOutputSink _service;
        public OutputWriterTests()
        {
            _service = new ConsoleOutputSink();
        }

        [Fact]
        public void Given_NotFound_Command_Returns_NotFound_String()
        {
            _service.Write("foo: command not found");

            //Assert.Equal("foo: command not found", result);
        }
    }
}
