using System;
using EnterpriseAssistant.API.Interfaces;

namespace EnterpriseAssistant.API.Services;

public class PdfTextExtractor : IPdfTextExtractor
{
    public Task<IReadOnlyList<string>> ExtractTextAsync(string filePath)
    {
        if (String.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty.");
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The specified file does not exist.", filePath);
        }

        if (!string.Equals(Path.GetExtension(filePath), ".pdf", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Only PDF files are allowed.");
        }

        var pageTexts = new List<string>();


         using ( var pdf = UglyToad.PdfPig.PdfDocument.Open(filePath))
        {
            foreach (var page in pdf.GetPages())
            {
                pageTexts.Add(page.Text);
            }
        }

        return Task.FromResult<IReadOnlyList<string>>(pageTexts);
    }
    
}
