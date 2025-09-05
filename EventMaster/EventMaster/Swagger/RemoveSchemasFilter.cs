/*using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

public class RemoveSchemasFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        // List of schemas to remove completely
        var removeList = new List<string>
        {
            "Attachment",
            "AttachmentDTO",
            "Event",
            "EventDTO",
            "User",
            "UserDTO",
            "LoginDTO",
            "Notification",
            "NotificationDTO",
            "SavedEvent",
            "SavedEventDTO",
            "Ticket",
            "TicketDTO",
            "UserRole",
            "Category",
            "CategoryDTO",
            "ProblemDetails"
        };

        foreach (var schemaName in removeList)
        {
            if (swaggerDoc.Components.Schemas.ContainsKey(schemaName))
            {
                swaggerDoc.Components.Schemas.Remove(schemaName);
            }
        }
    }
}
*/