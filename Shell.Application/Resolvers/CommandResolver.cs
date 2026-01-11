using Shell.Domain.Abstracts;
using Shell.Domain.Entities;

namespace Shell.Application.Resolvers
{
    public class CommandResolver : ICommandResolver
    {
        private readonly IEnumerable<ICommandHandler> _handlers;

        public CommandResolver(IEnumerable<ICommandHandler> handlers)
        {
            _handlers = handlers;
        }

        public CommandResolution Resolve(Command command)
        {
            var handler = _handlers.First(h => h.CanHandle(command));
            return handler.Handle(command);
        }
    }
}
