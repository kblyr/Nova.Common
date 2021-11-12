using Microsoft.AspNetCore.Http;

namespace Nova.Common.Security
{
    sealed class CurrentBoundariesProvider : ICurrentBoundariesProvider
    {
        static readonly IEnumerable<string> _empty = Enumerable.Empty<string>();

        readonly object _lockObj = new();
        readonly IHttpContextAccessor _contextAccessor;

        public CurrentBoundariesProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        IEnumerable<string>? _boundaries;
        public IEnumerable<string> Boundaries
        {
            get
            {
                lock(_lockObj)
                {
                    if (_boundaries is not null)
                        return _boundaries;

                    var context = _contextAccessor.HttpContext;

                    if (context is null)
                        return _empty;

                    var boundariesClaim = context.User.FindFirst(ClaimTypes.Boundaries);

                    if (boundariesClaim is null)
                        return _empty;

                    var boundaries = boundariesClaim.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    _boundaries = boundaries;
                    return _boundaries;
                }
            }
        }
    }
}