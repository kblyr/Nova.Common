using MediatR;

namespace Nova.Common.Security.AccessValidation
{
    abstract class ValidateAccessWrapper<TAccessValidationRule> : ValidateAccessWrapperBase where TAccessValidationRule : IAccessValidationRule
    {
        public abstract Task<bool> ValidateAsync(TAccessValidationRule rule, ServiceFactory factory, CancellationToken cancellationToken);
    }
}