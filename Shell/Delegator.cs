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

        public void Delegate(Command command, ShellExecutionContext context)
        {
            var commandHandler = _resolver.Resolve(command);

            commandHandler.Execute(command, context);
        }
    }
}
