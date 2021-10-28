using MediatR.Pipeline;
using Nova.Common.Security;
using Nova.Common.Validators.Exceptions;

namespace Nova.Common.Validators
{
    sealed class RequestAccessValidationProcessor<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        readonly IRequestAccessValidator<TRequest> _validator;
        readonly IPermissionsProvider _permissionsProvider;

        public RequestAccessValidationProcessor(IRequestAccessValidator<TRequest> validator, IPermissionsProvider permissionsProvider)
        {
            _validator = validator;
            _permissionsProvider = permissionsProvider;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAccessAsync(_permissionsProvider.Permissions, request, cancellationToken);

            if (!result.IsSuccess)
                throw new RequestAccessDeniedException { FailedPermissions = result.FailedPermissions };
        }
    }
}