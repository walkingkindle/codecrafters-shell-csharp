using Shell.Domain.Entities;

namespace Shell.Domain.Abstracts
{
    public abstract record ExecutableCommand(Command Command): CommandResolution;
}
