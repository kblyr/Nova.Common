using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Security
{
    public class SecurityDependencyBuilder : DependencyBuilder
    {
        public SecurityDependencyBuilder(IServiceCollection services) : base(services)
        {
        }
    }
}