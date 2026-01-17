using Shell.Domain.Abstracts;
using Shell.Domain.Entities;

namespace Shell.Application
{
    public class CommandClassifier(BuiltInKnowledgeProvider _provider) : ICommandClassifier
    {
        public CommandType Classify(string input)
        {
            return _provider.Exists(input) ? CommandType.BuiltIn : CommandType.NotFound;
        }
    }
}
