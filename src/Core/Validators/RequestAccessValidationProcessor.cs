using MediatR.Pipeline;
using Nova.Common.Security;
using Nova.Common.Validators.Exceptions;

namespace Nova.Common.Validators
{
    sealed class RequestAccessValidationProcessor<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        readonly IRequestAccessValidator<TRequest> _validator;
        readonly ICurrentPermissionsProvider _permissionsProvider;

        public RequestAccessValidationProcessor(IRequestAccessValidator<TRequest> validator, ICurrentPermissionsProvider permissionsProvider)
        {
            _validator = validator;
            _permissionsProvider = permissionsProvider;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var context = new RequestAccessValidationContext();
            await _validator.ValidateAccessAsync(context, _permissionsProvider.Permissions, request, cancellationToken);

            if (context.Result == RequestAccessValidationResult.Failed)
                throw new RequestAccessDeniedException { FailedPermissions = context.FailedPermissions };
        }
    }
}