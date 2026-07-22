namespace EnterpriseAssistant.API.Interfaces;
public interface IEmbeddingService
{
    Task<IReadOnlyList<float>> GenerateEmbeddingAsync(string text);
}