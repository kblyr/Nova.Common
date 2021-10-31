using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Security
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCurrentBoundariesProvider(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped) 
        {
            services.Add(new ServiceDescriptor(typeof(ICurrentBoundariesProvider), typeof(CurrentBoundariesProvider), lifetime));
            return services;
        }

        public static IServiceCollection AddCurrentPermissionsProvider(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(ICurrentPermissionsProvider), typeof(CurrentPermissionsProvider), lifetime));
            return services;
        }

        public static IServiceCollection AddCurrentRolesProvider(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(ICurrentRolesProvider), typeof(CurrentRolesProvider), lifetime));
            return services;
        }
    }
}