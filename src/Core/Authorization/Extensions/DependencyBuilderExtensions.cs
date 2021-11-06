namespace Nova.Common.Authorization
{
    public static class DependencyBuilderExtensions
    {
        static AuthorizationDependencyBuilder? _builder;
        public static AuthorizationDependencyBuilder AddAuthorization(this DependencyBuilder builder)
        {
            _builder ??= new(builder.Services);
            return _builder;
        }
    }
}