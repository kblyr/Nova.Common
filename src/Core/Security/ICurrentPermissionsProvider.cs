namespace Nova.Common.Security
{
    public interface ICurrentPermissionsProvider
    {
        IEnumerable<string> Permissions { get; }
    }
}