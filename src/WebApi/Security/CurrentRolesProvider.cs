using Microsoft.AspNetCore.Http;

namespace Nova.Common.Security
{
    sealed class CurrentRolesProvider : ICurrentRolesProvider
    {
        static readonly IEnumerable<string> _empty = Enumerable.Empty<string>();

        readonly object _lockObj = new();
        readonly IHttpContextAccessor _contextAccessor;

        public CurrentRolesProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        IEnumerable<string>? _roles;
        public IEnumerable<string> Roles
        {
            get
            {
                lock(_lockObj)
                {
                    if (_roles is not null)
                        return _roles;

                    var context = _contextAccessor.HttpContext;

                    if (context is null)
                        return _empty;


                    var rolesClaim = context.User.FindFirst(ClaimTypes.Roles);

                    if (rolesClaim is null)
                        return _empty;

                    var roles = rolesClaim.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    _roles = roles;
                    return _roles;
                }
            }
        }
    }
}