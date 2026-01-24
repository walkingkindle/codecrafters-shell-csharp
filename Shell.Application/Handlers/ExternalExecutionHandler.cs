using Shell.Domain.Abstracts;
using Shell.Domain.Entities;
using Shell.Infrastructure;

namespace Shell.Application.Handlers
{
    public class ExternalExecutionHandler(IExternalDiscoveryService _externalDiscoveryService, ProcessStarter _starter) : ICommandHandler
    {
        public bool CanHandle(Command command)
        {
            return _externalDiscoveryService.Exists(command.Input);
        }

        public void Execute(Command command, ShellExecutionContext context)
        {
            var path = _externalDiscoveryService.Get(command.Input).First();

            //var allArgs = new[] { }
            //.Concat(command.Arguments)
            //.ToArray();

            _starter.Start(Path.GetFileName(path), command.Arguments.ToArray());
            
        }
    }
}
