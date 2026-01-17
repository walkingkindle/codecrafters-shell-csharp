using Shell.Domain.Entities;
using System.Collections.Immutable;

namespace Shell.Tests.Domain
{
    public class CommandTests
    {
        [Fact]
        public void Command_CanBeCreated_WithNameAndArguments()
        {
            var args = new List<string> { "arg1", "arg2" };
            var command = new Command("test", args);

            Assert.Equal("test", command.Input);
            Assert.Equal(args, command.Arguments);
        }

        [Fact]
        public void CommandArguments_AreImmutable()
        {
            var args = new List<string> { "arg1", "arg2" };
            var command = new Command("test", args);

            args.Add("arg3");

            Assert.DoesNotContain("arg3", command.Arguments);
        }
    }
}
