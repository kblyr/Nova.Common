namespace Nova.Common.Authorization
{
    public static class DependencyBuilderExtensions
    {
        public static AuthorizationDependencyBuilder AddAuthorization(this DependencyBuilder builder) => new(builder.Services);
    }
}