using Microsoft.AspNetCore.Authorization;
using Nova.Common.Security.AccessValidation;

namespace Nova.Common.Authorization
{
    sealed class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        readonly IAccessValidator _accessValidator;

        public PermissionAuthorizationHandler(IAccessValidator accessValidator)
        {
            _accessValidator = accessValidator;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
        {
            if (context.User.Identity is null || !context.User.Identity.IsAuthenticated)
                return;

            var rules = new AccessValidationRuleEnumerable();

            foreach(var permission in requirement.Permissions)
            {
                rules.AddPermission(permission);
            }

            if (rules.Count == 0 || await _accessValidator.ValidateAsync(AuthorizationCheckModeConverter.ToAccessValidationMode(requirement.CheckMode), rules))
                context.Succeed(requirement);
        }
    }
}