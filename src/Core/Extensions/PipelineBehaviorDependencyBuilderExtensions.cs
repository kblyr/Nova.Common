using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common
{
    public static class PipelineBehaviorDependencyBuilderExtensions
    {
        public static PipelineBehaviorDependencyBuilder Add(PipelineBehaviorDependencyBuilder builder, Type openGenericPipelineBehaviorContractType, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            builder.Services.AddOpenGenericPipelineBehaviorImplementationType(openGenericPipelineBehaviorContractType);
            return builder;
        }
    }
}