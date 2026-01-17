
using Shell.Domain.Abstracts;

namespace Shell.Domain.Commands
{
    public sealed record Echo : IBuiltInCommand
    {
        public string Name => "echo";
    }
}
