using System.Data;
using System.Security.AccessControl;

namespace Shell.Infrastructure
{
    public class PermissionValidator
    {
        public bool HasExecutePermissions(string filePath)
        {
            if (!File.Exists(filePath))
                return false;

            var mode = File.GetUnixFileMode(filePath);

            return mode.HasFlag(UnixFileMode.UserExecute)
                || mode.HasFlag(UnixFileMode.GroupExecute)
                || mode.HasFlag(UnixFileMode.OtherExecute);
        }
    }
}
