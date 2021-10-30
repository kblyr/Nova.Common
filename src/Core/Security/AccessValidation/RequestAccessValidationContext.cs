namespace Nova.Common.Security.AccessValidation
{
    sealed class RequestAccessValidationContext : IRequestAccessValidationContext
    {
        readonly AccessValidationRuleEnumerable _rules = new();
        public AccessValidationMode Mode { get; private set; } = AccessValidationMode.Any;
        public IAccessValidationRuleEnumerable Rules => _rules;

        public IRequestAccessValidationContext Require(IAccessValidationRule rule)
        {
            _rules.Add(rule);
            return this;
        }

        public IRequestAccessValidationContext WithMode(AccessValidationMode mode)
        {
            Mode = mode;
            return this;
        }
    }
}