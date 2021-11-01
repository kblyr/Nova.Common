using CodeCompanion.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Nova.Common.Security
{
    sealed class CurrentFootprintProvider : ICurrentFootprintProvider
    {
        readonly IHttpContextAccessor _contextAccessor;

        public CurrentFootprintProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        Footprint? _current;
        public Footprint Current
        {
            get
            {
                if (_current is not null)
                    return _current.Value;

                var context = _contextAccessor.HttpContext;
                var defaultFootprint = new Footprint(null, DateTimeOffset.Now);

                if (context is null)
                    return defaultFootprint;

                if (context.User.Identity is null)
                    return defaultFootprint;

                if (!context.User.Identity.IsAuthenticated)
                    return defaultFootprint;

                var userIdClaim = context.User.FindFirst(ClaimTypes.UserId);

                if (userIdClaim is null)
                    return defaultFootprint;

                if (!int.TryParse(userIdClaim.Value, out int userId))
                    return defaultFootprint;

                var current = new Footprint(userId, DateTimeOffset.Now);
                _current = current;
                return current;
            }
        }
    }
}