using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common
{
    public static class IServiceCollectionExtensions
    {
        static readonly Type _openGenericPipelineBehaviorContractType = typeof(IPipelineBehavior<,>);

        static DependencyBuilder? _builder;
        static PipelineBehaviorDependencyBuilder? _pipelineBuilder;

        public static DependencyBuilder AddNovaCommon(this IServiceCollection services)
        {
            _builder ??= new(services);
            return _builder;
        }

        public static PipelineBehaviorDependencyBuilder WithPipelineBehaviors(this IServiceCollection services)
        {
            _pipelineBuilder ??= new(services);
            return _pipelineBuilder;
        }

        public static IServiceCollection AddOpenGenericPipelineBehaviorImplementationType(this IServiceCollection services, Type openGenericPipelineBehaviorImplementationType, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(_openGenericPipelineBehaviorContractType, openGenericPipelineBehaviorImplementationType, lifetime));
            return services;
        }

        public static IServiceCollection ConfigureFromSection<TOptions>(this IServiceCollection services, IConfiguration configuration, string configKey) where TOptions : class => services
            .Configure<TOptions>(configuration.GetSection(configKey));
    }
}