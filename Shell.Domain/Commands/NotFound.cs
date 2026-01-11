using Shell.Domain.Abstracts;

namespace Shell.Domain.Commands
{
    public sealed record CommandNotFound(string commandName):CommandResolution;


}
