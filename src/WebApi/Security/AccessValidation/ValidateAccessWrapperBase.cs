using MediatR;

namespace Nova.Common.Security.AccessValidation
{
    abstract class ValidateAccessWrapperBase
    {
        public abstract Task<bool> ValidateAsync(object rule, ServiceFactory factory, CancellationToken cancellationToken);

        protected static T GetImplementation<T>(ServiceFactory factory)
        {
            T? implementation;

            try
            {
                implementation = factory.GetInstance<T>();
            }
            catch (Exception)
            {
                throw;
            }

            return implementation ?? throw new InvalidOperationException($"{nameof(implementation)} is null");
        }
    }
}