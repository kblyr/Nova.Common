using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Nova.Common.Security.AccessValidation
{
    public static class AccessValidationDependencyBuilderExtensions
    {
        public static AccessValidationDependencyBuilder AddAccessValidator(this AccessValidationDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.Add(new ServiceDescriptor(typeof(IAccessValidator), typeof(AccessValidator), lifetime));
            return builder;
        }

        public static AccessValidationDependencyBuilder AddRequestAccessValidationProcessor(this AccessValidationDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.Add(new ServiceDescriptor(typeof(IPipelineBehavior<,>), typeof(RequestAccessValidationProcessor<,>), lifetime));
            return builder;
        }
    }
}