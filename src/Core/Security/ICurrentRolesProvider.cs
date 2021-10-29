namespace Nova.Common.Security
{
    public interface ICurrentRolesProvider
    {
        IEnumerable<string> Roles { get; }
    }
}