using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Validators
{
    public class ValidatorsDependencyBuilder : DependencyBuilder
    {
        public ValidatorsDependencyBuilder(IServiceCollection services) : base(services)
        {
        }
    }
}