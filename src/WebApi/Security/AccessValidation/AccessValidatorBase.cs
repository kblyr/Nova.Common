using Nova.Common.Security.AccessValidation.Exceptions;

namespace Nova.Common.Security.AccessValidation
{
    public abstract class AccessValidatorBase
    {
        protected abstract Task<bool> ValidateAsync(IAccessValidationRule rule, CancellationToken cancellationToken);

        public async Task<bool> ValidateAsync(AccessValidationMode mode, IAccessValidationRuleEnumerable rules, CancellationToken cancellationToken = default)
        {
            if (rules.Count == 0)
                throw new ArgumentException("No rules to validate");

            return mode switch
            {
                AccessValidationMode.Any => await ValidateAnyAsync(rules, cancellationToken),
                AccessValidationMode.All => await ValidateAllAsync(rules, cancellationToken),
                _ => throw new InvalidOperationException($"Value for enum '{typeof(AccessValidationMode).Name}' is not supported")
            };
        }

        async Task<bool> ValidateAnyAsync(IAccessValidationRuleEnumerable rules, CancellationToken cancellationToken)
        {
            var failedRules = new List<IAccessValidationRule>();

            foreach (var rule in rules)
            {
                if (await ValidateAsync(rule, cancellationToken))
                    return true;
                else
                    failedRules.Add(rule);
            }

            throw new AccessValidationFailedException {  FailedRules = failedRules };
        }

        async Task<bool> ValidateAllAsync(IAccessValidationRuleEnumerable rules, CancellationToken cancellationToken)
        {
            foreach (var rule in rules)
            {
                if (!await ValidateAsync(rule, cancellationToken))
                    throw new AccessValidationFailedException { FailedRules = new[] { rule } };
            }

            return true;
        }
    }
}