using Nova.Common.Security.AccessValidation.Rules;

namespace Nova.Common.Security.AccessValidation.Validations
{
    sealed class VAByRole : IValidateAccess<AVRRole>
    {
        readonly object _lockObj = new();
        readonly ICurrentRolesProvider _rolesProvider;
        HashSet<string>? _roles;

        public VAByRole(ICurrentRolesProvider rolesProvider)
        {
            _rolesProvider = rolesProvider;
        }

        public ValueTask<bool> ValidateAsync(AVRRole rule, CancellationToken cancellationToken = default)
        {
            lock(_lockObj)
            {
                if (_roles is null)
                    _roles = new(_rolesProvider.Roles);

                return ValueTask.FromResult(_roles.Contains(rule.Role));
            }
        }
    }
}