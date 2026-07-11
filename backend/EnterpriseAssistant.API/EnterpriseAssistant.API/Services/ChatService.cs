using EnterpriseAssistant.API.Interfaces;
using EnterpriseAssistant.API.Models;

namespace EnterpriseAssistant.API.Services;

public class ChatService : IChatService
{
    public  Task<ChatResponse> GetChatResponse(ChatRequest request, CancellationToken cancellationToken)
    {
        var response = new ChatResponse
            {

                Answer = "Employees receive 20 vacation days.",
                Source = "VacationPolicy.pdf"
            };
        return Task.FromResult(response);
    }
}
