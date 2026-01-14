using Shell.Domain.Abstracts;
using Shell.Domain.Entities;

namespace Shell.Application.Handlers
{
    public class EchoHandler : ICommandHandler
    {
        public bool CanHandle(Command command) => 
            command.Input.Equals("echo", StringComparison.OrdinalIgnoreCase);
        public void Execute(Command command, ShellExecutionContext context) => 
            context.Emit(string.Join(" ", command.Arguments));

        
    }
}
