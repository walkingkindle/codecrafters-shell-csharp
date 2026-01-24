namespace Shell.Infrastructure
{
    public class EnvironmentVariableParser
    {
        public string? GetEnvironmentVariable(string variableKey) => Environment.GetEnvironmentVariable(variableKey);
    }
}
