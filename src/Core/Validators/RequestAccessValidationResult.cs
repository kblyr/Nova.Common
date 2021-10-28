namespace Nova.Common.Validators
{
    public record RequestAccessValidationResult
    {
        public bool IsSuccess { get; init; }
        public IEnumerable<string> FailedPermissions { get; init; } = Enumerable.Empty<string>();
    }
}