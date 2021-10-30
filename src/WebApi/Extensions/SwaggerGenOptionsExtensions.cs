using Microsoft.Extensions.DependencyInjection;
using Nova.Common.Schema;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nova.Common
{
    public static class SwaggerGenOptionsExtensions
    {
        public static void UseNovaSchemaIds(this SwaggerGenOptions options)
        {
            options.CustomSchemaIds(type => {
                var schemaIdAttribs = type.GetCustomAttributes(typeof(SchemaIdAttribute), false);

                if (schemaIdAttribs.Any() && schemaIdAttribs[0] is SchemaIdAttribute schemaId)
                    return schemaId.SchemaId;

                return type.Name;
            });
        }
    }
}