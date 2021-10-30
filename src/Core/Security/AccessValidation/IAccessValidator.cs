namespace Nova.Common.Security.AccessValidation
{
    public interface IAccessValidator 
    {
        Task<bool> ValidateAsync(AccessValidationMode mode, IAccessValidationRuleEnumerable rules, CancellationToken cancellationToken = default);
    }
}