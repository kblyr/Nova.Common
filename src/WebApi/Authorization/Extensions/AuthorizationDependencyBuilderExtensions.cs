using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Authorization
{
    public static class AuthorizationDependencyBuilderExtensions
    {
        public static AuthorizationDependencyBuilder AddPolicyProvider(this AuthorizationDependencyBuilder builder)
        {
            builder.Services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            return builder;
        }

        public static AuthorizationDependencyBuilder AddAuthorizationHandlers(this AuthorizationDependencyBuilder builder)
        {
            builder.Services
                .AddScoped<IAuthorizationHandler, RoleAuthorizationHandler>()
                .AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            return builder;
        }
    }
}