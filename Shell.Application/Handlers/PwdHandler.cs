using Shell.Domain.Abstracts;
using Shell.Domain.Entities;
using Shell.Infrastructure;

namespace Shell.Application.Handlers
{
    public class PwdHandler(PathReader _reader) : ICommandHandler
    {
        public bool CanHandle(Command command) => command.Input.Equals("pwd", StringComparison.OrdinalIgnoreCase);

        public void Execute(Command command, ShellExecutionContext context)
        {
            context.Emit(_reader.CurrentWorkingDirectory());
        }
            
    }
}
