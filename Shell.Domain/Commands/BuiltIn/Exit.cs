
using Shell.Domain.Abstracts;

namespace Shell.Domain.Commands
{
    public sealed record Exit : IBuiltInCommand
    {
        public string Name => "exit";
    }
}
