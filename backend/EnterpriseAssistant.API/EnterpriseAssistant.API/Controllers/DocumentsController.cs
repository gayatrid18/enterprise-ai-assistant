using EnterpriseAssistant.API.Interfaces;
using EnterpriseAssistant.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAssistant.API.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
  _documentService = documentService;
        } 

        [HttpPost("upload")]
        public async Task<ActionResult<DocumentUploadResponse>> Upload(IFormFile file, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _documentService.UploadAsync(file, cancellationToken);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
