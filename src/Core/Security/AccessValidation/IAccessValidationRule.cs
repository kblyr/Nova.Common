namespace Nova.Common.Security.AccessValidation
{
    public interface IAccessValidationRule
    {
        string RuleName { get; }
        IDictionary<string, object?> GetPayload();
    }
}