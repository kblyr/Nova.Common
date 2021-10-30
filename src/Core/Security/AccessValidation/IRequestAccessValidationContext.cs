namespace Nova.Common.Security.AccessValidation
{
    public interface IRequestAccessValidationContext
    {
        IRequestAccessValidationContext WithMode(AccessValidationMode mode);
        IRequestAccessValidationContext Require(IAccessValidationRule rule);
    }
}