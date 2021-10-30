namespace Nova.Common.Security.AccessValidation
{
    public interface IRequestAccessValidationConfiguration<TRequest> where TRequest : notnull
    {
        void Configure(IRequestAccessValidationContext context, TRequest request);
    }
}