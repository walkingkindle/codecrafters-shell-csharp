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

        public ICommandHandler Resolve(Command command)
        {
            return _handlers.First(x => x.CanHandle(command));
        }
    }
}
