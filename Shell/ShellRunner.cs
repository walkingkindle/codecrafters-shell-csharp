using Shell.Application;
using Shell.Domain.Abstracts;
using Shell.Infrastructure;

namespace Shell
{
    public class ShellRunner : IShellRunner
    {
        private readonly Delegator _delegator;
        private readonly IOutputSink _outputSink;
        private readonly PathReader _pathReader;

        public ShellRunner(Delegator delegator, IOutputSink outputSink, PathReader pathReader)
        {
            _delegator = delegator;
            _outputSink = outputSink;
            _pathReader = pathReader;
        }

        public void Run()
        {
            var context = new ShellExecutionContext(_outputSink, true, _pathReader.CurrentWorkingDirectory());
            while (context.IsRunning)
            {
                Console.Write("$ ");       
                var input = Console.ReadLine();
                if (input != null)
                {
                    _delegator.Delegate(input, context); 
                }
            }
        }
    }
}
