namespace Shell.Domain.Abstracts
{
    public interface IExternalDiscoveryService
    {
        public string[] Get(string serviceName);
    }
}
