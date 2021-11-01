namespace Nova.Common.Validators
{
    public static class DependencyBuilderExtensions
    {
        public static ValidatorsDependencyBuilder AddValidators(this DependencyBuilder builder) => new(builder.Services);
    }
}