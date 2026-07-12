using System;
using EnterpriseAssistant.API.Models;

namespace EnterpriseAssistant.API.Interfaces;

public interface IDocumentService
{
    Task<DocumentUploadResponse> UploadAsync(IFormFile file, CancellationToken cancellationToken);
}
