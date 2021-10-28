namespace Nova.Common.Security
{
    public interface IPermissionsProvider
    {
        IEnumerable<string> Permissions { get; }
    }
}