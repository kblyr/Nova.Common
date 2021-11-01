using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Security.AccessValidation
{
    public static class IServiceCollectionExtensions
    {
        static readonly Type _genericType_IValidateAccess = typeof(IValidateAccess<>);
        static readonly Type _genericType_IRequestAccessValidationConfiguration = typeof(IRequestAccessValidationConfiguration<>);

        public static IServiceCollection AddValidateAccessImplementations(this IServiceCollection services, Assembly assemblyMarker, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            foreach (var implementation in assemblyMarker.GetSpecificImplementationTypesOfGenericInterfaceType(_genericType_IValidateAccess))
            {
                services.Add(new ServiceDescriptor(implementation.GetSpecificInterfaceType(_genericType_IValidateAccess), implementation, lifetime));
            }

            return services;
        }

        public static IServiceCollection AddRequestAccessValidationConfigurations(this IServiceCollection services, Assembly assemblyMarker, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            foreach (var implementation in assemblyMarker.GetSpecificImplementationTypesOfGenericInterfaceType(_genericType_IRequestAccessValidationConfiguration))
            {
                services.Add(new ServiceDescriptor(implementation.GetSpecificInterfaceType(_genericType_IRequestAccessValidationConfiguration), implementation, lifetime));
            }

            return services;
        }
    }
}