using System.Text;

namespace Nova.Common.Authorization
{
    static class AuthorizePolicyBuilder
    {
        public static string Build(string variant, AuthorizationCheckMode checkMode, string[] items) => new StringBuilder()
            .Append(variant)
            .Append(AuthorizationDefaults.Policy.ChunkSeparator)
            .Append(AuthorizationCheckModeConverter.ToString(checkMode))
            .Append(AuthorizationDefaults.Policy.ChunkSeparator)
            .Append(string.Join(AuthorizationDefaults.Policy.ItemSeparator, items))
            .ToString();
    }
}