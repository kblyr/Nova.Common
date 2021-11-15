using System.Text;
using CodeCompanion.Exceptions;

namespace Nova.Common.Exceptions
{
    public class NovaException : CodeCompanionException 
    {
        public string? ErrorCode { get; init; }

        protected override void SetClientMessage(StringBuilder builder)
        {
            builder
                .Append("An error has occured.")
                .AppendIf($" Error Code: {ErrorCode}", ErrorCode is not null);
        }
    }
}