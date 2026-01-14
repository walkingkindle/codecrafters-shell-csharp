using Shell.Domain.Entities;

namespace Shell.Domain.Abstracts;
public interface ICommandResolver
{
    ICommandHandler Resolve(Command command);
}
