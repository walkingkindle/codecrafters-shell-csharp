
namespace Shell.Infrastructure
{
    public class PathSetter
    {
        private readonly PathReader _pathReader;

        public PathSetter(PathReader pathReader)
        {
            _pathReader = pathReader;
        }

        public string SetCurrentDirectory(string directory)
        {
            if (IsHomeDirectory(directory))
            {
                directory = _pathReader.GetHomeDirectory();
            }
            try
            {
                Directory.SetCurrentDirectory(directory);
            }
            catch (DirectoryNotFoundException ex)
            {
                string error = $"No such directory, {directory}";

                return error;
            }

            return "";
        }

        private bool IsHomeDirectory(string directory)
        {
            return directory == "~";
        }
    }
}
