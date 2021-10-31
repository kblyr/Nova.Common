using CodeCompanion.Extensions;
using System.Reflection;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Security.AccessValidation
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestAccessValidationProcessor(this IServiceCollection services) => services
            .AddScoped(typeof(IRequestPreProcessor<>), typeof(RequestAccessValidationProcessor<>));

        public static IServiceCollection AddValidateAccessImplementations(this IServiceCollection services, Assembly assemblyMarker, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var implementations = assemblyMarker.GetConcreteImplementationsOf(typeof(IValidateAccess<>));

            foreach (var implementation in implementations)
                services.Add(new ServiceDescriptor(implementation.GetInterfaces()[0], implementation, lifetime));

            return services;
        }

        public static IServiceCollection AddValidateAccessImplementations(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped) => services.AddValidateAccessImplementations(CoreAssemblyMarker.Assembly, lifetime);

        public static IServiceCollection AddRequestAccessValidationConfigurations(this IServiceCollection services, Assembly assemblyMarker, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var implementations = assemblyMarker.GetConcreteImplementationsOf(typeof(IRequestAccessValidationConfiguration<>));

            foreach (var implementation in implementations)
                services.Add(new ServiceDescriptor(implementation.GetInterfaces()[0], implementation, lifetime));

            return services;
        }
    }
}