using System.Collections;

namespace Nova.Common.Security.AccessValidation
{
    public class AccessValidationRuleEnumerable : IAccessValidationRuleEnumerable
    {
        readonly List<IAccessValidationRule> _source = new();

        public int Count => _source.Count;

        public IAccessValidationRuleEnumerable Add(IAccessValidationRule rule)
        {
            _source.Add(rule);
            return this;
        }

        public IEnumerator<IAccessValidationRule> GetEnumerator() => _source.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}