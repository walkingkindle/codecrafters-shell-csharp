using Shell.Application.Handlers;
using Shell.Application.Resolvers;
using Shell.Domain.Abstracts;
using Shell.Domain.Commands;
using Shell.Domain.Entities;

namespace Shell.Tests.Application
{
    public class CommandResolverTests
    {
        private readonly CommandResolver _commandResolver;

        public CommandResolverTests()
        {
            var notFoundHandler = new NotFoundHandler();
            var handlers = new List<ICommandHandler> {notFoundHandler };
            _commandResolver = new CommandResolver(handlers);
        }

        [Fact]
        public void Return_NotFound_Command_If_Command_Does_NotExist()
        {
            var command = new Command("foo", new List<string> { });

            var result = _commandResolver.Resolve(command);

            Assert.NotNull(result);

        }
    }
}
