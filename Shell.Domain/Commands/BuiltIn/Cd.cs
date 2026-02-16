using Shell.Domain.Abstracts;

namespace Shell.Domain.Commands.BuiltIn
{
    public sealed record Cd : IBuiltInCommand
    {
        public string Name => "cd";
    }
}
