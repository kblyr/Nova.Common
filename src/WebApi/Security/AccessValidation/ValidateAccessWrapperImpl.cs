using MediatR;

namespace Nova.Common.Security.AccessValidation
{
    internal sealed class ValidateAccessWrapperImpl<TAccessValidationRule> : ValidateAccessWrapper<TAccessValidationRule> where TAccessValidationRule : IAccessValidationRule
    {
        public override async Task<bool> ValidateAsync(TAccessValidationRule rule, ServiceFactory factory, CancellationToken cancellationToken) => await GetImplementation<IValidateAccess<TAccessValidationRule>>(factory).ValidateAsync(rule, cancellationToken);

        public override async Task<bool> ValidateAsync(object rule, ServiceFactory factory, CancellationToken cancellationToken) => await ValidateAsync((TAccessValidationRule)rule, factory, cancellationToken);
    }
}