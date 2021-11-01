using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Security
{
    public static class SecurityDependencyBuilderExtensions
    {
        public static SecurityDependencyBuilder AddCurrentBoundariesProvider(this SecurityDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.Add(new ServiceDescriptor(typeof(ICurrentBoundariesProvider), typeof(CurrentBoundariesProvider), lifetime));
            return builder;
        }

        public static SecurityDependencyBuilder AddCurrentRolesProvider(this SecurityDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.Add(new ServiceDescriptor(typeof(ICurrentRolesProvider), typeof(CurrentRolesProvider), lifetime));
            return builder;
        }

        public static SecurityDependencyBuilder AddCurrentPermissionsProvider(this SecurityDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.Add(new ServiceDescriptor(typeof(ICurrentPermissionsProvider), typeof(CurrentPermissionsProvider), lifetime));
            return builder;
        }
    }
}