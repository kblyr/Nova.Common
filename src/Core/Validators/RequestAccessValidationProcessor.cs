using MediatR.Pipeline;

namespace Nova.Common.Validators
{
    sealed class RequestAccessValidationProcessor<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        readonly IRequestAccessValidator<TRequest> _validator;

        public RequestAccessValidationProcessor(IRequestAccessValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}