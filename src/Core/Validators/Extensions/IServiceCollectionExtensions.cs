using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Nova.Common.Validators
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestValidationProcessor(this IServiceCollection services) => services
            .AddScoped(typeof(IRequestPreProcessor<>), typeof(RequestValidationProcessor<>));
    }
}