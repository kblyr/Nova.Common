using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Security.AccessValidation
{
    public static class AccessValidationDependencyBuilderExtensions
    {
        public static AccessValidationDependencyBuilder AddAccessValidator(this AccessValidationDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.AddAccessValidator(lifetime);
            return builder;
        }

        public static AccessValidationDependencyBuilder AddValidateAccessImplementations(this AccessValidationDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.AddValidateAccessImplementations(CoreAssemblyMarker.Assembly, lifetime);
            return builder;
        }

        public static AccessValidationDependencyBuilder AddRequestAccessValidationProcessor(this AccessValidationDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.AddRequestAccessValidationProcessor(lifetime);
            return builder;
        }
    }
}