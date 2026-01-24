using Shell.Infrastructure;

namespace Shell.Application
{
    public class ExternalKnowledgeProvider(EnvironmentVariableParser _parser)
    {
        public bool Exists(string name)
        {
            return _parser.GetEnvironmentVariable(name) != null;
        }
    }
}
