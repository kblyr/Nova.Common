using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Authorization
{
    public class AuthorizationDependencyBuilder : DependencyBuilder
    {
        public AuthorizationDependencyBuilder(IServiceCollection services) : base(services)
        {
        }
    }
}