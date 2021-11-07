using Microsoft.Extensions.Configuration;
using Nova.Common.Configuration;
using Nova.Common.Security;
using Nova.Common.Security.AccessValidation;
using Nova.Common.Validators;

namespace Nova.Common
{
    public static class DependencyBuilderExtensions
    {
        public static DependencyBuilder WithDefaults(this DependencyBuilder builder) => builder
            .AddSecurity()
                .AddAccessValidation()
                    .AddAccessValidator()
                    .AddValidateAccessImplementations()
                .AddValidators();

        public static DependencyBuilder ConfigureOptions(this DependencyBuilder builder, IConfiguration configuration)
        {
            builder.Services
                .ConfigureAccessToken(configuration);
            return builder;
        }
    }
}