using Shell.Domain.Abstracts;
using Shell.Domain.Entities;
using Shell.Infrastructure;

namespace Shell.Application.Handlers
{
    public class CdHandler : ICommandHandler
    {
        private readonly PathSetter _pathSetter;
        private readonly PathReader _pathReader;

        public CdHandler(PathSetter pathSetter, PathReader pathReader)
        {
            _pathSetter = pathSetter;
            _pathReader = pathReader;
        }

        public bool CanHandle(Command command)
            => command.Input.Equals("cd");
        

        public void Execute(Command command, ShellExecutionContext context)
        {
            var path = command.Arguments.First();
            var pathError = _pathSetter.SetCurrentDirectory(path);

            if (!string.IsNullOrEmpty(pathError))
            {
                context.Emit($"cd: {path}: No such file or directory");
            }

            context.ChangeCurrentWorkingDirectory(_pathReader.CurrentWorkingDirectory());

            
        }
    }
}
