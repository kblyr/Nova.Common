namespace Nova.Common.Security.AccessValidation
{
    public interface IRequestAccessValidationContext
    {
        IRequestAccessValidationContext Require(IAccessValidationRule rule);
    }
}