namespace EnterpriseAssistant.API.Models;

public record class TextChunk
{
public string Text { get; init; }
public int ChunkIndex { get; init; }
public int PageNumber { get; init; }

}
