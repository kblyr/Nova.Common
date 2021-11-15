using System.Text;

namespace Nova.Common
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendIf(this StringBuilder builder, string value, bool condition) => condition ? builder.Append(value) : builder;

        public static StringBuilder AppendIf(this StringBuilder builder, string value, Func<bool> condition) => builder.AppendIf(value, condition());
    }
}