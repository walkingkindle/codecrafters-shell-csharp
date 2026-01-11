using Shell.Domain.Abstracts;
using Shell.Domain.Commands;
using Shell.Output;

namespace Shell.Tests.Presentation
{
    public class OutputWriterTests
    {
        private readonly OutputWriter _service;
        public OutputWriterTests()
        {
            _service = new OutputWriter();
        }

        [Fact]
        public void Given_NotFound_Command_Returns_NotFound_String()
        {
            var result = _service.WriteOutput(new CommandNotFound("foo"));

            Assert.Equal("foo: command not found", result);
        }
    }
}
