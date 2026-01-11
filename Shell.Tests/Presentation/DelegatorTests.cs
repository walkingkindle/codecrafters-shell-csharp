using Moq;
using Shell.Application.Output;
using Shell.Application.Resolvers;
using Shell.Domain.Abstracts;
using Shell.Domain.Commands;
using Shell.Domain.Entities;

namespace Shell.Tests.Presentation
{
    public class DelegatorTests
    {
        private readonly Delegator _delegator;
        public DelegatorTests()
        {
            var outputMocker = new Mock<IOutputWriter>();
            var notFoundHandler = new NotFoundHandler();
            var handlers = new List<ICommandHandler> { notFoundHandler };
            var commandResolver = new CommandResolver(handlers);
            _delegator = new Delegator(commandResolver, outputMocker.Object);
        }

        [Fact]
        public void NotFound_Input_Delegates_To_OutputWriter_With_CommandNotFound()
        {
            // Arrange
            CommandResolution? capturedResolution = null;
            var outputMocker = new Mock<IOutputWriter>();
            outputMocker
                .Setup(w => w.WriteOutput(It.IsAny<CommandResolution>()))
                .Callback<CommandResolution>(res => capturedResolution = res)
                .Returns("mocked result");

            var notFoundHandler = new NotFoundHandler();
            var handlers = new List<ICommandHandler> { notFoundHandler };
            var commandResolver = new CommandResolver(handlers);

            var delegator = new Delegator(commandResolver, outputMocker.Object);

            var command = new Command("foo", new List<string> { "bar" });

            // Act
            var result = delegator.Delegate(command);

            // Assert
            Assert.IsType<CommandNotFound>(capturedResolution); // resolution is CommandNotFound
            var notFound = capturedResolution as CommandNotFound;
            Assert.Equal("foo", notFound!.CommandName); // the command name matches
            Assert.Equal("mocked result", result); // Delegate returns writer output
        }

    }
}
