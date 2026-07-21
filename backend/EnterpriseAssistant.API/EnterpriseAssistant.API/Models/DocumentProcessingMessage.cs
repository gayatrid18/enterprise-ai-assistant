using System;

namespace EnterpriseAssistant.API.Models;

public record DocumentProcessingMessage
{
    public Guid DocumentId { get; init; }

    public string FilePath { get; init; }

    public string Status { get; set; }

}
