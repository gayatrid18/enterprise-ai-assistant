using EnterpriseAssistant.API.Interfaces;
using EnterpriseAssistant.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAssistant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChatRequest request, CancellationToken cancellationToken)
        {
            var response = await _chatService.GetChatResponse(request, cancellationToken);
            return Ok(response);
        }
    }
}


