using EnterpriseAssistant.API.Interfaces;
using EnterpriseAssistant.API.Models;

namespace EnterpriseAssistant.API.Services;

public class ChatService : IChatService
{
    public async Task<ChatResponse> GetChatResponse(ChatRequest request, CancellationToken cancellationToken)
    {
        return new ChatResponse
            {

                Answer = "Employees receive 20 vacation days.",
                Source = "VacationPolicy.pdf"
            };
    }
}
