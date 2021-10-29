namespace Nova.Common.Authorization
{
    static class AuthorizationCheckModeConverter
    {
        public static string ToString(AuthorizationCheckMode checkMode) => checkMode switch
        {
            AuthorizationCheckMode.Any => nameof(AuthorizationCheckMode.Any),
            AuthorizationCheckMode.All => nameof(AuthorizationCheckMode.All),
            _ => throw new NotSupportedException($"Value of parameter '{nameof(checkMode)}' is unsupported")
        };
    }
}