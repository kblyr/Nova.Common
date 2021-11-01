using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common
{
    public static class IServiceCollectionExtensions
    {
        public static DependencyBuilder AddNovaCommon(this IServiceCollection services)
        {
            return new(services);
        }
    }
}