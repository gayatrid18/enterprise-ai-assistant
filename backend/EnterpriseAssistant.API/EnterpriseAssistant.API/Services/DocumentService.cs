using EnterpriseAssistant.API.Interfaces;
using EnterpriseAssistant.API.Models;

namespace EnterpriseAssistant.API.Services;

public class DocumentService : IDocumentService
{
    private readonly IPdfTextExtractor _pdfTextExtractor;
    public DocumentService(IPdfTextExtractor pdfTextExtractor)
    {
        _pdfTextExtractor = pdfTextExtractor;
    }
    
    public async Task<DocumentUploadResponse> UploadAsync(IFormFile file, CancellationToken cancellationToken)
    {

        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("Non-empty file is required.");
        }

        if (!string.Equals(
Path.GetExtension(file.FileName),
".pdf",
StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Only PDF files are allowed.");
        }

        string documentsPath = Path.Combine(Directory.GetCurrentDirectory(), "Documents");
        Directory.CreateDirectory(documentsPath);

        string safeFileName = Path.GetFileName(file.FileName);
        string filePath = Path.Combine(documentsPath, safeFileName);
        await using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);

        await file.CopyToAsync(stream, cancellationToken);
        return new DocumentUploadResponse
        {
            FileName = safeFileName,
            FileSize = file.Length,
            UploadDate = DateTime.UtcNow
        };
    }
}
