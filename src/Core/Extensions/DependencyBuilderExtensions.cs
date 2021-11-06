using Nova.Common.Security;
using Nova.Common.Security.AccessValidation;
using Nova.Common.Validators;

namespace Nova.Common
{
    public static class DependencyBuilderExtensions
    {
        public static DependencyBuilder WithDefaults(this DependencyBuilder builder, Action<PipelineBehaviorDependencyBuilder>? configurePipelineBehaviors = null)
        {
            var pipelineBehaviors = new PipelineBehaviorDependencyBuilder(builder.Services);

            builder
                .AddSecurity()
                    .AddAccessValidation()
                        .AddAccessValidator()
                        .AddValidateAccessImplementations()
                    .AddValidators();

            if (configurePipelineBehaviors is not null)
            {
                configurePipelineBehaviors(pipelineBehaviors);
            }
            else
            {
                pipelineBehaviors
                    .AddRequestValidation()
                    .AddRequestAccessValidation();
            }

            return builder;
        }
    }
}