/*using EventMaster.DTOs;
using EventMaster.Models;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

public class IgnoreSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        // Add here the DTOs/entities you don't want to appear in Swagger Schemas
        var excludedTypes = new[]
        {
            typeof(AttachmentDTO),
            typeof(Attachment),
            typeof(EventDTO),
            typeof(Event),
            typeof(UserDTO),
            typeof(User)
        };

        if (excludedTypes.Contains(context.Type))
        {
            schema.Properties.Clear();
            schema.Type = "object"; // Swagger will just show "object" instead of full schema
        }
    }
}
*/