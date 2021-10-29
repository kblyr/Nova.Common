using Microsoft.AspNetCore.Authorization;

namespace Nova.Common.Authorization
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public AuthorizationCheckMode CheckMode { get; }
        public string[] Permissions { get; }

        public PermissionAuthorizationRequirement(AuthorizationCheckMode checkMode, string[] permissions)
        {
            CheckMode = checkMode;
            Permissions = permissions;
        }        
    } 
}