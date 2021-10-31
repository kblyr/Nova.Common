using MediatR.Pipeline;

namespace Nova.Common.Security.AccessValidation
{
    sealed class RequestAccessValidationProcessor<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        readonly IEnumerable<IRequestAccessValidationConfiguration<TRequest>> _configurations;
        readonly IAccessValidator _validator;

        public RequestAccessValidationProcessor(IEnumerable<IRequestAccessValidationConfiguration<TRequest>> configurations, IAccessValidator validator)
        {
            _configurations = configurations;
            _validator = validator;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var context = new RequestAccessValidationContext();

            foreach (var configuration in _configurations)
                configuration.Configure(context, request);

            await _validator.ValidateAsync(AccessValidationMode.All, context.Rules, cancellationToken);
        }
    }
}