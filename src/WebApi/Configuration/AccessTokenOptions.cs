namespace Nova.Common.Configuration
{
    public record AccessTokenOptions
    {
        public string IssuerSigningKey { get; init; } = "";
        public TimeSpan Expiration { get; init; }
        public string HeaderName { get; init; } = "";
        public bool RequireHttpsMetadata { get; init; }
        public bool SaveToken { get; init; }
        public TimeSpan ClockSkew { get; init; }
        public bool ValidateIssuerSigningKey { get; init; }
        public bool ValidateIssuer { get; init; }
        public bool ValidateAudience { get; init; }
        public bool ValidateLifetime { get; init; }
        public string ValidIssuer { get; init; } = "";
        public string ValidAudience { get; init; } = "";
    }
}