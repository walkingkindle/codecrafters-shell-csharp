
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
            var homeDrive = Environment.GetEnvironmentVariable("HOMEDRIVE");
            if (!string.IsNullOrWhiteSpace(homeDrive))
            {
                var homePath = Environment.GetEnvironmentVariable("HOMEPATH");
                if (!string.IsNullOrWhiteSpace(homePath))
                {
                    return homeDrive + Path.DirectorySeparatorChar + homePath;
                }
                else
                {
                    throw new Exception("Environment variable error, there is no 'HOMEPATH'");
                }
            }
            else
            {
                throw new Exception("Environment variable error, there is no 'HOMEDRIVE'");
            }
        }
    }
}
