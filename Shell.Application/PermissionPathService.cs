using Shell.Domain.Abstracts;
using Shell.Infrastructure;

namespace Shell.Application
{
    public class PermissionPathService(PermissionValidator _validator) : IPermissionService
    {
        public bool HasExecutePermission(string commandName)
        {
            var pathVariable = Environment.GetEnvironmentVariable("PATH");

            return _validator.HasExecutePermissions(Path.Combine(pathVariable!, commandName));
        }
    }
}
