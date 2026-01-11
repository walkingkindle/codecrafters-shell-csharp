using Shell.Domain.Abstracts;
using Shell.Domain.Commands;
using Shell.Domain.Concepts;
using Shell.Domain.Entities;

namespace Shell.Tests.Domain
{
    public class CommandResolutionTests
    {
        [Fact]
        public void CommandNotFound_HoldsCommandName()
        {
            var notFound = new CommandNotFound("foo");

            Assert.Equal("foo", notFound.CommandName);
        }

        [Fact]
        public void BuiltInCommand_InheritsFromExecutableCommand()
        {
            var cmd = new Command("ls", new List<string>());
            var builtIn = new BuiltInCommand(cmd, "ls");

            Assert.IsAssignableFrom<ExecutableCommand>(builtIn);
            Assert.Equal(cmd, builtIn.Command);
            Assert.Equal("ls", builtIn.BuiltInName);
        }

        [Fact]
        public void ExternalCommand_InheritsFromExecutableCommand()
        {
            var cmd = new Command("grep", new List<string>());
            var external = new ExternalCommand(cmd, "/usr/bin/grep");

            Assert.IsAssignableFrom<ExecutableCommand>(external);
            Assert.Equal(cmd, external.Command);
            Assert.Equal("/usr/bin/grep", external.ExecutablePath);
        }

        [Fact]
        public void ExecutableCommand_IsAbstract()
        {
            var type = typeof(ExecutableCommand);
            Assert.True(type.IsAbstract);
        }
    }
}
