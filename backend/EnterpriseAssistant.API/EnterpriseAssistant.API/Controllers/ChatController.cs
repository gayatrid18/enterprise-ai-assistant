using EnterpriseAssistant.API.Interfaces;
using EnterpriseAssistant.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAssistant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        public IChatService ChatService { get; }

        public ChatController(IChatService chatService)
        {
            ChatService = chatService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ChatRequest request)
        {
            var response = ChatService.GetChatResponse(request);
            return Ok(response);
        }
    }
}


