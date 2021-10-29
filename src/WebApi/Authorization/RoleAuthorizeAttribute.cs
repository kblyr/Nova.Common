using Microsoft.AspNetCore.Authorization;

namespace Nova.Common.Authorization
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public RoleAuthorizeAttribute(AuthorizationCheckMode checkMode, params string[] roles)
        {
            Policy = AuthorizePolicyBuilder.Build(AuthorizationDefaults.Policy.Prefixes.Role, checkMode, roles);
        }
    }
}