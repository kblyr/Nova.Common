using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Configuration
{
    public static class IConfigurationExtensions
    {
        public static AccessTokenOptions GetAccessToken(this IConfiguration configuration)
        {
            var options = new AccessTokenOptions();
            configuration.Bind(AccessTokenOptions.ConfigKey, options);
            return options;
        }
    }
}