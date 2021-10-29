namespace Nova.Common.Security
{
    public interface ICurrentBoundariesProvider
    {
        public IEnumerable<string> Boundaries { get; }
    }
}