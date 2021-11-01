using Microsoft.AspNetCore.Authorization;
using Nova.Common.Security.AccessValidation;

namespace Nova.Common.Authorization
{
    sealed class RoleAuthorizationHandler : AuthorizationHandler<RoleAuthorizationRequirement>
    {
        readonly IAccessValidator _accessValidator;

        public RoleAuthorizationHandler(IAccessValidator accessValidator)
        {
            _accessValidator = accessValidator;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleAuthorizationRequirement requirement)
        {
            if (context.User.Identity is null || !context.User.Identity.IsAuthenticated)
                return;

                var rules = new AccessValidationRuleEnumerable();

                foreach (var role in requirement.Roles)
                {
                    rules.AddRole(role);
                }
                
                if (rules.Count == 0 || await _accessValidator.ValidateAsync(AuthorizationCheckModeConverter.ToAccessValidationMode(requirement.CheckMode), rules))
                    context.Succeed(requirement);
        }
    }
}