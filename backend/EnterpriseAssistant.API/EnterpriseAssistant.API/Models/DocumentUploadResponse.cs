using System;

namespace EnterpriseAssistant.API.Models;

public class DocumentUploadResponse
{
public string FileName { get; set; } = string.Empty;
public long FileSize { get; set; }
public DateTime UploadDate { get; set; }
}
