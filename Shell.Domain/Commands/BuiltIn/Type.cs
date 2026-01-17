using Shell.Domain.Abstracts;

namespace Shell.Domain.Commands
{
    public sealed record Type : IBuiltInCommand
    {
        public string Name => "type";
    }
}
