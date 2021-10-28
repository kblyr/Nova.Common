using System.Runtime.Serialization;

namespace Nova.Common.Validators.Exceptions
{
    public class RequestAccessDeniedException : Exception
    {
        public IEnumerable<string> FailedPermissions { get; init; } = Enumerable.Empty<string>();

        public RequestAccessDeniedException()
        {
        }

        public RequestAccessDeniedException(string? message) : base(message)
        {
        }

        public RequestAccessDeniedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RequestAccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}