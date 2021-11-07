using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Validators
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestValidationProcessor(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.AddOpenGenericPipelineBehaviorImplementationType(typeof(RequestValidationProcessor<,>), lifetime);
            return services;
        }
    }
}