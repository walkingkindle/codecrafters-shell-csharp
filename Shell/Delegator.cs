using Shell.Domain.Abstracts;
using Shell.Domain.Commands;
using Shell.Domain.Concepts;
using Shell.Domain.Entities;

namespace Shell
{
    public class Delegator
    {
        private readonly ICommandResolver _resolver;

        public Delegator(ICommandResolver resolver)
        {
            _resolver = resolver;
        }

        public string Delegate(Command command)
        {
            var resolution = _resolver.Resolve(command);

            string result = "";

            switch (resolution)
            {
                case BuiltInCommand builtin:
                    break;
                case ExternalCommand external:
                    break;
                case CommandNotFound notFound:
                    result = $"{notFound.commandName}: command not found";
                    break;
            }

            return result;
        }
    }
}
