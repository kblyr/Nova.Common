using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Security.AccessValidation
{
    public class AccessValidationDependencyBuilder : SecurityDependencyBuilder
    {
        public AccessValidationDependencyBuilder(IServiceCollection services) : base(services)
        {
        }
    }
}