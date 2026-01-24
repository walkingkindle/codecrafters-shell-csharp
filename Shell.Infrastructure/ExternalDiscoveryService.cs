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
                var path = Path.Combine(directory, serviceName);
                if(File.Exists(path))
                    results.Add(path);
            }
            return results.ToArray();
        }
    }
}
