using System.Reflection;

namespace Nova.Common
{
    public static class CoreAssemblyMarker
    {
        public static readonly Assembly Assembly = typeof(CoreAssemblyMarker).Assembly; 
    }
}