namespace Nova.Common.Security.AccessValidation
{
    public static class SecurityDependencyBuilderExtensions
    {
        static AccessValidationDependencyBuilder? _builder;

        public static AccessValidationDependencyBuilder AddAccessValidation(this SecurityDependencyBuilder builder)
        {
            _builder ??= new(builder.Services);
            return _builder;
        }
    }
}