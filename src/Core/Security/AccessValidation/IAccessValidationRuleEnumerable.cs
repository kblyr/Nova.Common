namespace Nova.Common.Security.AccessValidation
{
    public interface IAccessValidationRuleEnumerable : IEnumerable<IAccessValidationRule>
    {
        public int Count { get; }
        IAccessValidationRuleEnumerable Add(IAccessValidationRule rule);
    }
}