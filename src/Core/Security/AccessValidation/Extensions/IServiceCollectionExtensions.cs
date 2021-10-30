using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Security.AccessValidation
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestAccessValidationProcessor(this IServiceCollection services) => services
            .AddScoped(typeof(IRequestPreProcessor<>), typeof(RequestAccessValidationProcessor<>));
    }
}