using Shell.Application.Output;
using Shell.Domain.Abstracts;
using Shell.Domain.Commands;
using Shell.Domain.Concepts;
using Shell.Domain.Entities;

namespace Shell
{
    public class Delegator
    {
        private readonly ICommandResolver _resolver;
        private readonly IOutputWriter _writer;

        public Delegator(ICommandResolver resolver, IOutputWriter writer)
        {
            _resolver = resolver;
            _writer = writer;
        }

        public string Delegate(Command command)
        {
            var resolution = _resolver.Resolve(command);

            return _writer.WriteOutput(resolution);
        }
    }
}
