namespace Nova.Common.Security.AccessValidation
{
    abstract class AccessValidationRuleBase
    {
        public IDictionary<string, object?> GetPayload()
        {
            var payload = new Dictionary<string, object?>();
            SetPayload(payload);
            return payload;
        }

        protected virtual void SetPayload(IDictionary<string, object?> payload)
        {
            // Override to set the payload
        }
    }
}