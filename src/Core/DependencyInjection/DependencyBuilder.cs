using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common
{
    public class DependencyBuilder
    {
        public IServiceCollection Services { get; }

        public DependencyBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}