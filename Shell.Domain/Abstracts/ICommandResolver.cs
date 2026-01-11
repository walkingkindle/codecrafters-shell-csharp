using Shell.Domain.Entities;

namespace Shell.Domain.Abstracts;
public interface ICommandResolver
{
    CommandResolution Resolve(Command command);
}
