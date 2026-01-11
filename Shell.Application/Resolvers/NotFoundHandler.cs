using Shell.Domain.Abstracts;
using Shell.Domain.Commands;
using Shell.Domain.Entities;

namespace Shell.Application.Resolvers;

public class NotFoundHandler : ICommandHandler
{
    public bool CanHandle(Command command) => true;

    public CommandResolution Handle(Command command)
    {
        return new CommandNotFound(command.Name);
    }
}
