using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Nova.Common.Validators
{
    sealed class RequestValidationProcessor<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationProcessor(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = new List<ValidationFailure>();

            foreach (var validator in _validators)
            {
                var result = await validator.ValidateAsync(context, cancellationToken);

                if (result.Errors is not null)
                    failures.AddRange(result.Errors);
            }

            if (failures.Any())
                throw new ValidationException(failures);

            return await next().ConfigureAwait(false);
        }
    }
}