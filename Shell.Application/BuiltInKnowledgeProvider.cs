using Shell.Domain.Abstracts;

namespace Shell.Application
{
    public class BuiltInKnowledgeProvider
    {
        private readonly IEnumerable<IBuiltInCommand> _builtInCommands;
        public BuiltInKnowledgeProvider(IEnumerable<IBuiltInCommand> commands)
        {
            _builtInCommands = commands;
        }

        public bool Exists(string name) => _builtInCommands.Any(c => c.Name == name);

    }
}
