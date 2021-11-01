using Nova.Common.Authorization;
using Nova.Common.Security;

namespace Nova.Common
{
    public static class DependencyBuilderExtensions
    {
        public static DependencyBuilder WithDefaultsForWebApi(this DependencyBuilder builder) => builder
            .AddAuthorization()
                .AddPolicyProvider()
                .AddAuthorizationHandlers()
            .AddSecurity()
                .AddCurrentBoundariesProvider()
                .AddCurrentRolesProvider()
                .AddCurrentPermissionsProvider();
    }
}