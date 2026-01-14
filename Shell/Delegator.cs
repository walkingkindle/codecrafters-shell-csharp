using Shell.Domain.Abstracts;
using Shell.Domain.Commands;
using Shell.Domain.Concepts;
using Shell.Domain.Entities;

namespace Shell
{
    public class Delegator
    {
        private readonly ICommandResolver _resolver;
        private readonly ICommandInterpreter _interpreter;

        public Delegator(ICommandResolver resolver, ICommandInterpreter interpreter)
        {
            _resolver = resolver;
            _interpreter = interpreter;
        }

        public void Delegate(string input, ShellExecutionContext context)
        {
            var command = _interpreter.Interpret(input);

            var commandHandler = _resolver.Resolve(command);

            commandHandler.Execute(command, context);
        }
    }
}
