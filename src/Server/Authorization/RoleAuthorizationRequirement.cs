using Microsoft.AspNetCore.Authorization;

namespace Nova.Common.Authorization
{
    public class RoleAuthorizationRequirement : IAuthorizationRequirement
    {
        public AuthorizationCheckMode CheckMode { get; }
        public string[] Roles { get; }

        public RoleAuthorizationRequirement(AuthorizationCheckMode checkMode, string[] roles)
        {
            CheckMode = checkMode;
            Roles = roles;
        }
    }
}