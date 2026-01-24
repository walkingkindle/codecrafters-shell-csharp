namespace Shell.Domain.Abstracts
{
    public interface IPermissionService
    {
        bool HasExecutePermission(string commandName);
    }
}
