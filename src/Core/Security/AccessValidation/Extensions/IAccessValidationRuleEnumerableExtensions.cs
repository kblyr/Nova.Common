using Nova.Common.Security.AccessValidation.Rules;

namespace Nova.Common.Security.AccessValidation
{
    public static class IAccessValidationRuleEnumerableExtensions
    {
        public static IAccessValidationRuleEnumerable AddRole(this IAccessValidationRuleEnumerable rules, string role) => rules.Add(new AVRRole(role));

        public static IAccessValidationRuleEnumerable AddPermission(this IAccessValidationRuleEnumerable rules, string permission) => rules.Add(new AVRPermission(permission));
    }

    public static class IRequestAccessValidationContextExtensions
    {
        public static IRequestAccessValidationContext RequireRole(this IRequestAccessValidationContext context, string role) => context.Require(new AVRRole(role));

        public static IRequestAccessValidationContext RequirePermission(this IRequestAccessValidationContext context, string permission) => context.Require(new AVRPermission(permission));

        public static IRequestAccessValidationContext RequireIf(this IRequestAccessValidationContext context, IAccessValidationRule rule, bool condition) 
        {
            if (condition)
                context.Require(rule);

            return context;
        }

        public static IRequestAccessValidationContext RequireRoleIf(this IRequestAccessValidationContext context, string role, bool condition) => context.RequireIf(new AVRRole(role), condition);

        public static IRequestAccessValidationContext RequirePermissionIf(this IRequestAccessValidationContext context, string permission, bool condition) => context.RequireIf(new AVRRole(permission), condition);
    }
}