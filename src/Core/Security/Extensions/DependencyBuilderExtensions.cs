namespace Nova.Common.Security
{
    public static class DependencyBuilderExtensions
    {
        public static SecurityDependencyBuilder AddSecurity(this DependencyBuilder builder) => new(builder.Services);
    }
}