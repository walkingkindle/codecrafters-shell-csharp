using Shell.Domain.Abstracts;
using Shell.Domain.Entities;
using Shell.Infrastructure;

namespace Shell.Application.Handlers
{
    public class TypeHandler(ICommandClassifier _classifier, IExternalDiscoveryService _externalDiscoveryService, IPermissionService _permissionService) : ICommandHandler
    {
        public bool CanHandle(Command command) =>
            command.Input.Equals("type", StringComparison.OrdinalIgnoreCase);

        public void Execute(Command command, ShellExecutionContext context)
        {
            var commandName = command.Arguments.Single();
            var type = _classifier.Classify(commandName);

            if (type == CommandType.BuiltIn)
                context.Emit($"{commandName} is a shell builtin");
            else if (type == CommandType.External)
                HandleExternalCommand(commandName, context);
            else
                CommandNotFound(commandName, context);
        }

        private void HandleExternalCommand(string commandName, ShellExecutionContext context)
        {
            var paths = _externalDiscoveryService.Get(commandName);

            if (paths == null || paths.Length == 0)
            {
                CommandNotFound(commandName, context);
                return;
            }

            foreach(var command in paths)
            {
                if (_permissionService.HasExecutePermission(command))
                {
                    context.Emit($"{commandName} is {command}");
                    return;
                }
            }
            CommandNotFound(commandName, context);
            return;
        }

        private static void CommandNotFound(string commandName, ShellExecutionContext context)
        {
            context.Emit($"{commandName}: not found");
        }
    }
}
