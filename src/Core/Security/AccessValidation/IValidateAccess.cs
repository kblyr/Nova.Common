namespace Nova.Common.Security.AccessValidation
{
    public interface IValidateAccess<TRule> where TRule : IAccessValidationRule
    {
        public ValueTask<bool> ValidateAsync(TRule rule, CancellationToken cancellationToken = default);
    }
}