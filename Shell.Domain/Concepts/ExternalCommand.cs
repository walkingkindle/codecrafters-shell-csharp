using Shell.Domain.Abstracts;
using Shell.Domain.Entities;

namespace Shell.Domain.Concepts
{
    public sealed record ExternalCommand(Command Command, string ExecutablePath):ExecutableCommand(Command);
}
