namespace Nova.Common.Validators
{
    public static class DependencyBuilderExtensions
    {
        static ValidatorsDependencyBuilder? _builder;
        public static ValidatorsDependencyBuilder AddValidators(this DependencyBuilder builder) 
        {
            _builder ??= new(builder.Services);
            return _builder;
        }
    }
}