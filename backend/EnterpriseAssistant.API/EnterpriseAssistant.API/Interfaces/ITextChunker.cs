using System;
using EnterpriseAssistant.API.Models;

namespace EnterpriseAssistant.API.Interfaces;

public interface ITextChunker
{
IReadOnlyList<TextChunk> CreateChunks(IReadOnlyList<string> pages, int chunkSize, int overlap);
}
