namespace Nova.Common.Security.AccessValidation
{
    sealed class RequestAccessValidationContext : IRequestAccessValidationContext
    {
        readonly AccessValidationRuleEnumerable _rules = new();
        public IAccessValidationRuleEnumerable Rules => _rules;

        public IRequestAccessValidationContext Require(IAccessValidationRule rule)
        {
            _rules.Add(rule);
            return this;
        }
    }
}