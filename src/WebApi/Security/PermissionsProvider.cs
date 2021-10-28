using Microsoft.AspNetCore.Http;

namespace Nova.Common.Security
{
    sealed class PermissionsProvider : IPermissionsProvider
    {
        readonly object _lockObj = new();
        readonly IHttpContextAccessor _contextAccessor;

        public PermissionsProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        IEnumerable<string>? _permissions;
        public IEnumerable<string> Permissions
        {
            get
            {
                lock (_lockObj)
                {
                    var empty = Enumerable.Empty<string>();

                    if (_permissions is not null)
                        return _permissions;

                    var context = _contextAccessor.HttpContext;

                    if (context is null)
                        return empty;

                    var permissionsClaim = context.User.FindFirst(ClaimTypes.Permissions);

                    if (permissionsClaim is null)
                        return empty;

                    var permissions = permissionsClaim.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    _permissions = permissions;
                    return _permissions;
                }
            }
        }
    }
}