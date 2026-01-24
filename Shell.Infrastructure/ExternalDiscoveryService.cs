using Shell.Domain.Abstracts;

namespace Shell.Infrastructure
{
    public class ExternalDiscoveryService : IExternalDiscoveryService
    {
        public string[] Get(string serviceName)
        {
            string? pathVariable = Environment.GetEnvironmentVariable("PATH");

            var directories = pathVariable.Split(Path.PathSeparator);

            var results = new List<string>();

            foreach (var directory in directories)
            {
                if(File.Exists(Path.Combine(directory, $"{serviceName}.exe")))
                    results.Add(directory);
            }
            return results.ToArray();
        }
    }
}
