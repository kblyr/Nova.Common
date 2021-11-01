namespace Nova.Common
{
    public static class TypeExtensions
    {
        public static Type GetSpecificInterfaceType(this Type type, Type genericInterfaceType) => type.GetInterfaces()
            .Single(interfaceType => interfaceType.GetGenericTypeDefinition().Equals(genericInterfaceType));
    }
}