namespace Nova.Common.Authorization
{
    static class AuthorizationDefaults
    {

        public static class Policy
        {
            public const char ChunkSeparator = '|';
            public const char ItemSeparator = ',';

            public static class Prefixes
            {
                public const string Role = "Nova.Authorization.Role";
                public const string Permission = "Nova.Authorization.Permission";
            }
        }
    }
}