using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Nova.Common.Configuration;

namespace Nova.Common
{
    public static class AuthenticationBuilderExtensions 
    {
        public static AuthenticationBuilder AddJwtBearerWithNovaDefaults(this AuthenticationBuilder builder, AccessTokenOptions accessTokenOptions) => builder
            .AddJwtBearer(options => {
                options.RequireHttpsMetadata = accessTokenOptions.RequireHttpsMetadata;
                options.SaveToken = accessTokenOptions.SaveToken;
                options.TokenValidationParameters = new()
                {
                    ClockSkew = accessTokenOptions.ClockSkew,
                    ValidateIssuerSigningKey = accessTokenOptions.ValidateIssuerSigningKey,
                    ValidateIssuer = accessTokenOptions.ValidateIssuer,
                    ValidateAudience = accessTokenOptions.ValidateAudience,
                    ValidateLifetime = accessTokenOptions.ValidateLifetime,
                    IssuerSigningKey = accessTokenOptions.GetSymmetricSecurityKey()
                };

                options.Events = new()
                {
                    OnAuthenticationFailed = context => 
                    {   
                        if (context.Exception.GetType().Equals(typeof(SecurityTokenExpiredException)))
                            context.Response.Headers.Add(accessTokenOptions.HeaderName, "TOKEN_EXPIRED");

                        return Task.CompletedTask;
                    }
                };
            });
    }
}