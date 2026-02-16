
namespace Shell.Infrastructure
{
    public class PathReader
    {
        public string CurrentWorkingDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public string GetHomeDirectory()
        {
            return Environment.GetEnvironmentVariable("HOME");
        }
    }
}
