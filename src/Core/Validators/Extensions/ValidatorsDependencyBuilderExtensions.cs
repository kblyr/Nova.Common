using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Validators
{
    public static class ValidatorsDependencyBuilderExtensions
    {
        public static ValidatorsDependencyBuilder AddRequestValidationProcessor(this ValidatorsDependencyBuilder bulider, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            bulider.Services.AddRequestValidationProcessor(lifetime);
            return bulider;
        }
    }
}