using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common
{
    public class PipelineBehaviorDependencyBuilder
    {
        public IServiceCollection Services { get; }

        public PipelineBehaviorDependencyBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}