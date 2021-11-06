using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common
{
    public static class IServiceCollectionExtensions
    {
        static DependencyBuilder? _builder;

        public static DependencyBuilder AddNovaCommon(this IServiceCollection services)
        {
            _builder ??= new(services);
            return _builder;
        }
    }
}