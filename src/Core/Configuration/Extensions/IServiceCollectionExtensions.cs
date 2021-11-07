using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Configuration
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAccessToken(this IServiceCollection services, IConfiguration configuration) => services
            .ConfigureFromSection<AccessTokenOptions>(configuration, AccessTokenOptions.ConfigKey);
    }
}