using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Nova.Common.Authorization
{
    sealed class AuthorizationPolicyProvider : IAuthorizationPolicyProvider
    {
        readonly DefaultAuthorizationPolicyProvider _fallbackPolicyProvider;
        readonly AuthorizationPolicy _defaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser()
            .Build();

        public AuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            _fallbackPolicyProvider = new(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => Task.FromResult(_defaultPolicy);

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => _fallbackPolicyProvider.GetFallbackPolicyAsync();

        public async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (!IsPolicyValidAndPrefixSupported(policyName))
                return await GetDefaultPolicyAsync();

            var policyChunks = policyName.Split(new[] { AuthorizationDefaults.Policy.ChunkSeparator }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (policyChunks.Length != 3)
                throw new InvalidOperationException("Policy is invalid");

            var prefix = policyChunks[0];
            var checkModeString = policyChunks[1];
            var checkMode = AuthorizationCheckMode.Any;
            var items = policyChunks[2].Split(new[] { AuthorizationDefaults.Policy.ItemSeparator }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (!Enum.TryParse(checkModeString, out checkMode))
                throw new InvalidOperationException($"Enum '{typeof(AuthorizationCheckMode).Name}' has no known value of '{checkModeString}'");

            if (items is null || items.Length == 0)
                throw new InvalidOperationException($"Empty policy");

            var policyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);

            switch (prefix)
            {
                case AuthorizationDefaults.Policy.Prefixes.Role:
                    policyBuilder.AddRequirements(new RoleAuthorizationRequirement(checkMode, items));
                    break;
                case AuthorizationDefaults.Policy.Prefixes.Permission:
                    policyBuilder.AddRequirements(new PermissionAuthorizationRequirement(checkMode, items));
                    break;
            }

            return policyBuilder.Build();
        }

        static bool IsPolicyValidAndPrefixSupported(string policyName) =>
            !string.IsNullOrWhiteSpace(policyName) &&
            (
                policyName.StartsWith(AuthorizationDefaults.Policy.Prefixes.Role) ||
                policyName.StartsWith(AuthorizationDefaults.Policy.Prefixes.Permission)
            );
    }
}