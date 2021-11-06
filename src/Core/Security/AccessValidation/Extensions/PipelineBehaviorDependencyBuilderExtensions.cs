using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Security.AccessValidation
{
    public static class PipelineBehaviorDependencyBuilderExtensions
    {
        public static PipelineBehaviorDependencyBuilder AddRequestAccessValidation(this PipelineBehaviorDependencyBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.AddRequestAccessValidationProcessor(lifetime);
            return builder;
        }
    }
}