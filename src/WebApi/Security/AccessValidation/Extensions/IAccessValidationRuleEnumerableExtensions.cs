using Nova.Common.Security.AccessValidation.Rules;

namespace Nova.Common.Security.AccessValidation
{
    public static class IAccessValidationRuleEnumerableExtensions
    {
        public static IAccessValidationRuleEnumerable AddRole(this IAccessValidationRuleEnumerable rules, string role) => rules.Add(new AVRRole(role));

        public static IAccessValidationRuleEnumerable AddPermission(this IAccessValidationRuleEnumerable rules, string permission) => rules.Add(new AVRPermission(permission));
    }
}