using Shell.Domain.Abstracts;
using Shell.Domain.Entities;
using Shell.Infrastructure;

namespace Shell.Application
{
    public class CommandClassifier(BuiltInKnowledgeProvider _builtInProvider, ExternalKnowledgeProvider _externalKnowledgeProvider) : ICommandClassifier
    {
        public CommandType Classify(string input)
        {
            if(_builtInProvider.Exists(input)) return CommandType.BuiltIn;

            if (_externalKnowledgeProvider.Exists("PATH"))
                return CommandType.External;

            return CommandType.NotFound;
        }
    }
}
