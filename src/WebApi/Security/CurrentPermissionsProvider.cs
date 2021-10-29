using Microsoft.AspNetCore.Http;

namespace Nova.Common.Security
{
    sealed class CurrentPermissionsProvider : ICurrentPermissionsProvider
    {
        static readonly IEnumerable<string> _empty = Enumerable.Empty<string>();

        readonly object _lockObj = new();
        readonly IHttpContextAccessor _contextAccessor;

        public CurrentPermissionsProvider(IHttpContextAccessor contextAccessor)
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
                    if (_permissions is not null)
                        return _permissions;

                    var context = _contextAccessor.HttpContext;

                    if (context is null)
                        return _empty;

                    var permissionsClaim = context.User.FindFirst(ClaimTypes.Permissions);

                    if (permissionsClaim is null)
                        return _empty;

                    var permissions = permissionsClaim.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    _permissions = permissions;
                    return _permissions;
                }
            }
        }
    }
}