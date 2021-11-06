using Nova.Common.Security;
using Nova.Common.Security.AccessValidation;
using Nova.Common.Validators;

namespace Nova.Common
{
    public static class DependencyBuilderExtensions
    {
        public static DependencyBuilder WithDefaults(this DependencyBuilder builder)
        {
            builder
                .AddSecurity()
                    .AddAccessValidation()
                        .AddAccessValidator()
                        .AddValidateAccessImplementations()
                    .AddValidators();

            builder.Services
                .AddRequestValidationProcessor();

            return builder;
        }
    }
}