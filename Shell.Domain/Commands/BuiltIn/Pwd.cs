using Shell.Domain.Abstracts;

namespace Shell.Domain.Commands.BuiltIn
{
    public sealed record Pwd : IBuiltInCommand
    {
        public string Name => "pwd";
    }
}
