namespace Nova.Common.Security
{
    public static class DependencyBuilderExtensions
    {
        static SecurityDependencyBuilder? _builder;
        public static SecurityDependencyBuilder AddSecurity(this DependencyBuilder builder)
        {
            _builder ??= new(builder.Services);
            return _builder;
        }
    }
}