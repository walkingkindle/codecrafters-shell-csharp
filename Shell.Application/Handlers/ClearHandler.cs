using Shell.Domain.Abstracts;
using Shell.Domain.Entities;

namespace Shell.Application.Handlers
{
    public class ClearHandler : ICommandHandler
    {
        public bool CanHandle(Command command) => command.Input.Equals("clear");

        public void Execute(Command command, ShellExecutionContext context)
        {
            context.ClearConsole();
        }
    }
}
