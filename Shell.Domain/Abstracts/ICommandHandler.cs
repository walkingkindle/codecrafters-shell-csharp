using Shell.Domain.Entities;

namespace Shell.Domain.Abstracts
{
    public interface ICommandHandler
    {
        bool CanHandle(Command command);
        CommandResolution Handle(Command command);
    }
}
