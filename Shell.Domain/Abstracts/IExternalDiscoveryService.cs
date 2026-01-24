namespace Shell.Domain.Abstracts
{
    public interface IExternalDiscoveryService
    {
        bool Exists(string input);
        public string[] Get(string serviceName);
    }
}
