using MediatR;

namespace Nova.Common.Security.AccessValidation
{
    sealed class RequestAccessValidationProcessor<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        readonly IEnumerable<IRequestAccessValidationConfiguration<TRequest>> _configurations;
        readonly IAccessValidator _validator;

        public RequestAccessValidationProcessor(IEnumerable<IRequestAccessValidationConfiguration<TRequest>> configurations, IAccessValidator validator)
        {
            _configurations = configurations;
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new RequestAccessValidationContext();

            foreach (var configuration in _configurations)
                configuration.Configure(context, request);

            await _validator.ValidateAsync(AccessValidationMode.All, context.Rules, cancellationToken);
            return await next().ConfigureAwait(false);
        }
    }
}