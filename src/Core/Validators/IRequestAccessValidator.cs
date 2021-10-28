namespace Nova.Common.Validators
{
    public interface IRequestAccessValidator<TRequest> where TRequest : notnull
    {
        Task<RequestAccessValidationResult> ValidateAccessAsync(RequestAccessValidationContext context, IEnumerable<string> permissions, TRequest request, CancellationToken cancellationToken);
    }
}