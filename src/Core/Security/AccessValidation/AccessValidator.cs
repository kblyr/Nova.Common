using System.Collections.Concurrent;
using MediatR;

namespace Nova.Common.Security.AccessValidation
{
    sealed class AccessValidator : AccessValidatorBase, IAccessValidator
    {
        static readonly ConcurrentDictionary<Type, ValidateAccessWrapperBase> _validateAccessImplementations = new();
        
        readonly ServiceFactory _serviceFactory;

        public AccessValidator(ServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        protected override async Task<bool> ValidateAsync(IAccessValidationRule rule, CancellationToken cancellationToken)
        {
            var ruleType = rule.GetType();

            var validateAccessImplementation = _validateAccessImplementations.GetOrAdd(ruleType,
                type => (ValidateAccessWrapperBase?)(Activator.CreateInstance(typeof(ValidateAccessWrapperImpl<>).MakeGenericType(ruleType)))
                ?? throw new InvalidOperationException($"Could not create wrapper for type '{ruleType.Name}'")
            );

            return await validateAccessImplementation.ValidateAsync(rule, _serviceFactory, cancellationToken);
        }
    }
}