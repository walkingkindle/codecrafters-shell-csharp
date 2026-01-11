using Shell.Domain.Abstracts;
using Shell.Domain.Entities;

namespace Shell.Domain.Concepts
{
    public sealed record BuiltInCommand(Command Command, string BuiltInName):ExecutableCommand(Command);
}
