namespace Nova.Common.Validators
{
    public interface IRequestAccessValidator<TRequest> where TRequest : notnull
    {
        Task<RequestAccessValidationResult> ValidateAccessAsync(IEnumerable<string> permissions, TRequest request, CancellationToken cancellationToken);
    }
}