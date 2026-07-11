using System;
using EnterpriseAssistant.API.Models;

namespace EnterpriseAssistant.API.Interfaces;

public interface IChatService
{
public ChatResponse GetChatResponse(ChatRequest message);
}
