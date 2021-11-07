using CodeCompanion.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Nova.Common.Security;

namespace Nova.Common
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
                var timestamp = DateTimeOffset.Now;
                var defaultFootprint = new Footprint(null, timestamp);
                var context = _contextAccessor.HttpContext;

                if (context is null)
                    return defaultFootprint;

                var userIdClaim = context.User.FindFirst(ClaimTypes.UserId);

                if (userIdClaim is null)
                    return defaultFootprint;

                if (!int.TryParse(userIdClaim.Value, out int userId))
                    return defaultFootprint;

                _current = new(userId, timestamp);
                return _current.Value;
            }
        }
    }
}