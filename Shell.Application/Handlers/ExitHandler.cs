using Shell.Domain.Abstracts;
using Shell.Domain.Entities;

namespace Shell.Application.Handlers
{
    public class ExitHandler : ICommandHandler
    {
        public bool CanHandle(Command command)
            => command.Input.Equals("exit", StringComparison.OrdinalIgnoreCase);

        public void Execute(Command command, ShellExecutionContext context) => context.Stop();

    }
}
