using CodeCompanion.FluentEnumerable;

namespace Nova.Common.Security.AccessValidation.Rules
{
    sealed class AVRRole : AccessValidationRuleBase, IAccessValidationRule
    {
        public string RuleName { get; } = AccessValidationRuleNames.Role;
        public string Role { get; }

        public AVRRole(string role)
        {
            Role = role;
        }

        protected override void SetPayload(IDictionary<string, object?> payload) => payload
            .FluentAdd(nameof(Role), Role);
    }
}