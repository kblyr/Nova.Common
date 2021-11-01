using System.Reflection;

namespace Nova.Common
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetSpecificImplementationTypesOfGenericInterfaceType(this Assembly assembly, Type genericInterfaceType) => assembly.GetTypes()
            .Where(type =>
                !type.IsGenericTypeDefinition &&
                !type.ContainsGenericParameters &&
                type.IsClass &&
                type.GetInterfaces().Any(interfaceType => interfaceType.GetGenericTypeDefinition().Equals(genericInterfaceType))
            );
    }
}