using Shell.Application;
using Shell.Domain.Abstracts;

namespace Shell
{
    public class ShellRunner : IShellRunner
    {
        private readonly Delegator _delegator;
        private readonly IOutputSink _outputSink;

        public ShellRunner(Delegator delegator, IOutputSink outputSink)
        {
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
                    _delegator.Delegate(input, context); 
                }
            }
        }
    }
}
