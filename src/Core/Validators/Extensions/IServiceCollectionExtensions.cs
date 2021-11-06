using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Validators
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestValidationProcessor(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(IPipelineBehavior<,>), typeof(RequestValidationProcessor<,>), lifetime));
            return services;
        }
    }
}