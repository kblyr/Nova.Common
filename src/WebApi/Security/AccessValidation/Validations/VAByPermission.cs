using Nova.Common.Security.AccessValidation.Rules;

namespace Nova.Common.Security.AccessValidation.Validations
{
    sealed class VAByPermission : IValidateAccess<AVRPermission>
    {
        readonly object _lockObj = new();
        readonly ICurrentPermissionsProvider _permissionsProvider;
        HashSet<string>? _permissions;

        public VAByPermission(ICurrentPermissionsProvider permissionsProvider)
        {
            _permissionsProvider = permissionsProvider;
        }

        public ValueTask<bool> ValidateAsync(AVRPermission rule, CancellationToken cancellationToken = default)
        {
            lock(_lockObj)
            {
                if (_permissions is null)
                    _permissions = new(_permissionsProvider.Permissions);

                return ValueTask.FromResult(_permissions.Contains(rule.Permission));
            }
        }
    }
}