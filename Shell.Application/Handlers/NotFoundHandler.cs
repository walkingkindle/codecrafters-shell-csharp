using Shell.Domain.Abstracts;
using Shell.Domain.Commands;
using Shell.Domain.Entities;

namespace Shell.Application.Handlers;

public class NotFoundHandler : ICommandHandler
{
    public bool CanHandle(Command command) => true;

    public void Execute(Command command, ShellExecutionContext context) => 
        context.Emit($"{command.Name}: command not found");
}
