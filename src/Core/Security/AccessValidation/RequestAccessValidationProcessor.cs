using MediatR.Pipeline;

namespace Nova.Common.Security.AccessValidation
{
    sealed class RequestAccessValidationProcessor<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        readonly IRequestAccessValidationConfiguration<TRequest> _configuration;
        readonly IAccessValidator _validator;

        public RequestAccessValidationProcessor(IRequestAccessValidationConfiguration<TRequest> configuration, IAccessValidator validator)
        {
            _configuration = configuration;
            _validator = validator;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var context = new RequestAccessValidationContext();
            _configuration.Configure(context, request);
            await _validator.ValidateAsync(context.Mode, context.Rules, cancellationToken);
        }
    }
}