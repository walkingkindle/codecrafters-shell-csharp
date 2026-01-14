using Shell.Application;
using Shell.Domain;
using Shell.Domain.Abstracts;
using Shell.Domain.Entities;
using Shell.Output;

namespace Shell
{
    public class ShellRunner : IShellRunner
    {
        private readonly ILogger<ShellRunner> _logger;
        private readonly Delegator _delegator;
        private readonly IOutputSink _outputSink;

        public ShellRunner(ILogger<ShellRunner> logger, Delegator delegator, IOutputSink outputSink)
        {
            _logger = logger;
            _delegator = delegator;
            _outputSink = outputSink;
        }

        public void Run()
        {
            var context = new ShellExecutionContext(_outputSink, true);
            while (context.IsRunning)
            {
                Console.Write("$ ");       
                var input = Console.ReadLine();
                if (input != null)
                {
                    var command = new Command(input, new List<string> { });

                    _delegator.Delegate(command, context); 
                }
            }
        }
    }
}
