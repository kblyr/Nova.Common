namespace Nova.Common.Security.AccessValidation
{
    public static class SecurityDependencyBuilderExtensions
    {
        public static AccessValidationDependencyBuilder AddAccessValidation(this SecurityDependencyBuilder builder) => new(builder.Services);
    }
}