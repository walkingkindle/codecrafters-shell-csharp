using System.Data;
using System.Security.AccessControl;

namespace Shell.Infrastructure
{
    public class PermissionValidator
    {
        public bool HasExecutePermissions(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            var fileSecurity = fileInfo.GetAccessControl();

            var accessRules = fileSecurity.GetAccessRules(true,true, typeof(System.Security.Principal.NTAccount));

            var currentUser = System.Security.Principal.WindowsIdentity.GetCurrent();

            foreach (FileSystemAccessRule accessRule in accessRules)
            {
                if (IsCurrentUser(currentUser, accessRule) && HasAccessRule(accessRule))
                    return true;
            }
            return false;
        }

        private static bool HasAccessRule(FileSystemAccessRule accessRule)
        {
            return (accessRule.FileSystemRights & FileSystemRights.ExecuteFile) == FileSystemRights.ExecuteFile;
        }

        private static bool IsCurrentUser(System.Security.Principal.WindowsIdentity currentUser, FileSystemAccessRule accessRule)
        {
            return accessRule.IdentityReference.Value.Equals(currentUser.Name, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
