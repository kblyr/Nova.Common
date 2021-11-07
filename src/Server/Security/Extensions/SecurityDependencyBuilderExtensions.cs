using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Security
{
    public static class SecurityDependencyBuilderExtensions
    {
        public static SecurityDependencyBuilder AddCurrentBoundariesProvider(this SecurityDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.AddCurrentBoundariesProvider(lifetime);
            return builder;
        }

        public static SecurityDependencyBuilder AddCurrentRolesProvider(this SecurityDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.AddCurrentRolesProvider(lifetime);
            return builder;
        }

        public static SecurityDependencyBuilder AddCurrentPermissionsProvider(this SecurityDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.AddCurrentPermissionsProvider(lifetime);
            return builder;
        }
    }
}