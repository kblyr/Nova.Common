using Microsoft.AspNetCore.Authorization;

namespace Nova.Common.Authorization
{
    public class PermissionAuthorizeAttribute : AuthorizeAttribute
    {
        public PermissionAuthorizeAttribute(AuthorizationCheckMode checkMode, params string[] permissions)
        {
            Policy = AuthorizePolicyBuilder.Build(AuthorizationDefaults.Policy.Prefixes.Permission, checkMode, permissions);
        }

        public PermissionAuthorizeAttribute(params string[] permissions) : this(AuthorizationCheckMode.Any, permissions) 
        {
        }
    }
}