using EnterpriseAssistant.API.Models;

namespace EnterpriseAssistant.API.Interfaces;
public interface IPdfTextExtractor
{
    Task<IReadOnlyList<string>> ExtractTextAsync(string filePath);
}