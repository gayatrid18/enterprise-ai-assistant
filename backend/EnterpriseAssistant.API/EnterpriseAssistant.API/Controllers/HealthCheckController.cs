using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAssistant.API.Controllers
{
    [Route("health")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "running", service = "Enterprise Knowledge Assistant", version = "1.0" });
        }
    }
}
