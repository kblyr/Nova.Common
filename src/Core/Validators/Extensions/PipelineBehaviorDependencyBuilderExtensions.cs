using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Validators
{
    public static class PipelineBehaviorDependencyBuilderExtensions
    {
        public static PipelineBehaviorDependencyBuilder AddRequestValidation(this PipelineBehaviorDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.AddRequestValidationProcessor(lifetime);
            return builder;
        }
    }
}