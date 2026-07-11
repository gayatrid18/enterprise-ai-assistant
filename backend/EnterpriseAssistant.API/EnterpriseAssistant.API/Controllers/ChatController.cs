using EnterpriseAssistant.API.Interfaces;
using EnterpriseAssistant.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAssistant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService ChatService;

        public ChatController(IChatService chatService)
        {
            ChatService = chatService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChatRequest request, CancellationToken cancellationToken)
        {
            var response = await ChatService.GetChatResponse(request, cancellationToken);
            return Ok(response);
        }
    }
}


