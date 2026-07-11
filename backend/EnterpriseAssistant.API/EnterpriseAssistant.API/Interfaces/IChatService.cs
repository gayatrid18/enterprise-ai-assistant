using EnterpriseAssistant.API.Models;

namespace EnterpriseAssistant.API.Interfaces;

public interface IChatService
{
public Task<ChatResponse> GetChatResponse(ChatRequest request, CancellationToken cancellationToken);
}
