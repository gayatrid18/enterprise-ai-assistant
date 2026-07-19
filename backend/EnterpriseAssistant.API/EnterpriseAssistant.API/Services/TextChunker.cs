using System;
using EnterpriseAssistant.API.Interfaces;
using EnterpriseAssistant.API.Models;

namespace EnterpriseAssistant.API.Services;

public class TextChunker : ITextChunker
{
    public IReadOnlyList<TextChunk> CreateChunks(IReadOnlyList<string> pages, int chunkSize, int overlap)
    {

        if (chunkSize <= 0)
        {
            throw new ArgumentException("Chunk size must be greater than zero.", nameof(chunkSize));
        }

        if (overlap < 0 || overlap >= chunkSize)
        {
            throw new ArgumentException("Overlap must be non-negative and less than chunk size.", nameof(overlap));
        }

        if (pages == null)
        {
            throw new ArgumentNullException("Pages cannot be null.", nameof(pages));
        }

        IList<TextChunk> chunks = new List<TextChunk>();
        int chunkIndex;
        int pageNumber = 1;

        foreach (var page in pages)
        {
            if (!string.IsNullOrEmpty(page))
            {
                var splitwords = page.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
                chunkIndex = 0;
                for (int i = 0; i < splitwords.Length; i = i + (chunkSize - overlap))
                {

                    chunks.Add(new TextChunk
                    {
                        Text = string.Join(' ', splitwords.Skip(i).Take(chunkSize)),
                        ChunkIndex = chunkIndex,
                        PageNumber = pageNumber
                    });


                    chunkIndex++;


                }
            }
            pageNumber++;

        }
        return chunks.AsReadOnly();
    }
}
