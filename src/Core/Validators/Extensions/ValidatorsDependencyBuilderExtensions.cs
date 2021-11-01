using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Validators
{
    public static class ValidatorsDependencyBuilderExtensions
    {
        public static ValidatorsDependencyBuilder AddRequestValidationProcessor(this ValidatorsDependencyBuilder bulider, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            bulider.Services.Add(new ServiceDescriptor(typeof(IPipelineBehavior<,>), typeof(RequestValidationProcessor<,>)));
            return bulider;
        }
    }
}