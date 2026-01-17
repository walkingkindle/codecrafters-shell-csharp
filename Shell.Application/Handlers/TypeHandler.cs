using Shell.Domain.Abstracts;
using Shell.Domain.Entities;

namespace Shell.Application.Handlers
{
    public class TypeHandler(ICommandClassifier _classifier) : ICommandHandler
    {
        public bool CanHandle(Command command) =>
            command.Input.Equals("type", StringComparison.OrdinalIgnoreCase);

        public void Execute(Command command, ShellExecutionContext context)
        {
            var commandName = command.Arguments.Single();
            var type = _classifier.Classify(commandName);

            if (type == CommandType.BuiltIn)
                context.Emit($"{commandName} is a shell builtin");
            else
                context.Emit($"{commandName}: not found");
        }
    }
}
