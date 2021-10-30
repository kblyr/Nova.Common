using System.Runtime.Serialization;

namespace Nova.Common.Security.AccessValidation.Exceptions
{
    public class AccessValidationFailedException : Exception
    {
        public IEnumerable<IAccessValidationRule> FailedRules { get; init; } = Enumerable.Empty<IAccessValidationRule>();

        public AccessValidationFailedException()
        {
        }

        public AccessValidationFailedException(string? message) : base(message)
        {
        }

        public AccessValidationFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AccessValidationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}