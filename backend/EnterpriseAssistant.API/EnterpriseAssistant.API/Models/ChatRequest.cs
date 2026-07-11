using System.ComponentModel.DataAnnotations;

namespace EnterpriseAssistant.API.Models;

public class ChatRequest
{
    [Required]
    [MinLength(1)]
    public string Question { get; set; } = string.Empty;
}