using System;
using EnterpriseAssistant.API.Interfaces;
using EnterpriseAssistant.API.Models;

namespace EnterpriseAssistant.API.Workers;

public class DocumentProcessingWorker : BackgroundService
{
    private readonly IPdfTextExtractor _textExtractor;
    private readonly ITextChunker _textChunker;
    public DocumentProcessingWorker(IPdfTextExtractor textExtractor, ITextChunker textChunker)
    {
        _textExtractor = textExtractor;
        _textChunker = textChunker;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while(!stoppingToken.IsCancellationRequested)
        {
            // Implement the logic for processing documents here
            // For example, you can extract text from a PDF and chunk it
        }
    }

    private async Task ProcessDocumentAsync(DocumentProcessingMessage message, CancellationToken cancellationToken)
    {
        if(message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }
        if(string.IsNullOrEmpty(message.FilePath))
        {
            throw new ArgumentException("FilePath cannot be null or empty.", nameof(message.FilePath));
        }
        if(!File.Exists(message.FilePath))
        {
            throw new FileNotFoundException($"The file '{message.FilePath}' does not exist.", message.FilePath);
        }

        message.Status = "Processing";
        try{
        var pages = await _textExtractor.ExtractTextAsync(message.FilePath);
        var chunks = _textChunker.CreateChunks(pages, 100,10);
        message.Status = "Completed";
        }
        catch(Exception ex)
        {
            message.Status = "Failed";
            throw; 
        }
      
    }
}
