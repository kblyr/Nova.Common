using CodeCompanion.FluentEnumerable;

namespace Nova.Common.Security.AccessValidation.Rules
{
    sealed class AVRPermission : AccessValidationRuleBase, IAccessValidationRule
    {
        public string RuleName { get; } = AccessValidationRuleNames.Permission;
        public string Permission { get; }

        public AVRPermission(string permission)
        {
            Permission = permission;
        }

        protected override void SetPayload(IDictionary<string, object?> payload) => payload
            .FluentAdd(nameof(Permission), Permission);
    }
}