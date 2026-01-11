using Shell.Domain;
using Shell.Domain.Entities;

namespace Shell
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Delegator _delegator;

        public Worker(ILogger<Worker> logger, Delegator delegator)
        {
            _logger = logger;
            _delegator = delegator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.Write("$ ");       
                var input = Console.ReadLine();

                if (input != null)
                {
                    var command = new Command(input, new List<string> { });

                    Console.WriteLine(_delegator.Delegate(command)); 
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
