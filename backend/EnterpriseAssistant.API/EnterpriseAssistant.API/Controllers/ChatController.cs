using EnterpriseAssistant.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAssistant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] ChatRequest request)
        {
            // Placeholder implementation - replace with actual chat logic
            return Ok(new ChatResponse
            {

                Answer = "Employees receive 20 vacation days.",
                Source = "VacationPolicy.pdf"
            });
        }
    }
}
