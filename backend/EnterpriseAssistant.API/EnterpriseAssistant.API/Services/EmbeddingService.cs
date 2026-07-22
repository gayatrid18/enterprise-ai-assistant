using EnterpriseAssistant.API.Interfaces;
using OpenAI;

namespace EnterpriseAssistant.API.Services;

public class EmbeddingService : IEmbeddingService
{
    private readonly OpenAIClient _openAiClient;
    
    private readonly string _embeddingModel;

    public EmbeddingService(OpenAIClient openAiClient, IConfiguration configuration)
    {
        _openAiClient = openAiClient;
        _embeddingModel = configuration["OpenAI:EmbeddingModel"] ?? throw new InvalidOperationException("OpenAI:EmbeddingModel configuration is missing.");
    }
    public async Task<IReadOnlyList<float>> GenerateEmbeddingAsync(string text)
    {
        if(string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Text cannot be null or whitespace.", nameof(text));
        }
        var response = await _openAiClient.GetEmbeddingClient(_embeddingModel).GenerateEmbeddingAsync(text);
        return response.Value.ToFloats().ToArray();
    }
}