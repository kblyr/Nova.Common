using CodeCompanion.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nova.Common.Authorization;
using Nova.Common.Security;

namespace Nova.Common
{
    public static class DependencyBuilderExtensions
    {
        public static DependencyBuilder WithServerDefaults(this DependencyBuilder builder) => builder
            .AddAuthorization()
                .AddPolicyProvider()
                .AddAuthorizationHandlers()
            .AddSecurity()
                .AddCurrentBoundariesProvider()
                .AddCurrentRolesProvider()
                .AddCurrentPermissionsProvider()
            .AddCurrentFootprintProvider();

        public static DependencyBuilder AddCurrentFootprintProvider(this DependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.Add(new ServiceDescriptor(typeof(ICurrentFootprintProvider), typeof(CurrentFootprintProvider), lifetime));
            return builder;
        }
    }
}