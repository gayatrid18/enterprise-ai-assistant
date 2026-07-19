using System.Runtime.CompilerServices;
using EnterpriseAssistant.API.Models;
using EnterpriseAssistant.API.Services;
using FluentAssertions;

namespace EnterpriseAssistant.API.Tests;

public class TextChunkerTests
{
    [Fact]
    public void GetChunks_ReturnsExpectedChunks()
    {
        var textChunker = new TextChunker();
        var input = new List<string> { "One Two Three Four Five Six Seven" }.AsReadOnly();
        var chunkSize = 4;
        var overlap = 1;

        var actualResult = textChunker.CreateChunks(input, chunkSize, overlap);

        var expectedRest = new List<TextChunk>
        {
            new TextChunk { Text = "One Two Three Four", ChunkIndex = 0, PageNumber = 1 },
            new TextChunk { Text = "Four Five Six Seven", ChunkIndex = 1, PageNumber = 1 },
           new TextChunk { Text = "Seven", ChunkIndex = 2, PageNumber = 1 }
        }.AsReadOnly();

        actualResult.Should().BeEquivalentTo(expectedRest, options => options.WithStrictOrdering());
        Assert.Equal(expectedRest.Count, actualResult.Count);

    }

    [Fact]
    public void CreateChunks_InvalidChunkSize_ThrowsArgumentException()
    {
        int chunkSize = 0;
        int overlap = 1;
        IReadOnlyList<string> input = new List<string> { "One Two Three Four Five Six Seven" }.AsReadOnly();
        var textChunker = new TextChunker();
        Assert.Throws<ArgumentException>(() => textChunker.CreateChunks(input, chunkSize, overlap));

    }

    [Fact]
    public void CreateChunks_InvalidOverlap_ThrowsArgumentException()
    {
        int chunkSize = 4;
        int overlap = 4;
        IReadOnlyList<string> input = new List<string> { "One Two Three Four Five Six Seven" }.AsReadOnly();
        var textChunker = new TextChunker();
        Assert.Throws<ArgumentException>(() => textChunker.CreateChunks(input, chunkSize, overlap));
    }

    [Fact]
    public void CreateChunks_NullInput_ThrowsArgumentNullEception()
    {
        var textChunker = new TextChunker();
        IReadOnlyList<string> input = null;
        var chunkSize = 4;
        var overlap = 1;

        Assert.Throws<ArgumentNullException>(() => textChunker.CreateChunks(input, chunkSize, overlap));
    }

    [Fact]
    public void CreateChunks_EmptyInput_ReturnEmptyList()
    {
        var textChunker = new TextChunker();
        IReadOnlyList<string> input = new List<string>().AsReadOnly();
        var chunkSize = 4;
        var overlap = 1;

        var actualResult = textChunker.CreateChunks(input, chunkSize, overlap);

        Assert.Empty(actualResult);
    }

    [Fact]
    public void CreateChunks_WhitespaceInput_ReturnsEmptyList()
    {
        var textChunker = new TextChunker();
        IReadOnlyList<string> input = new List<string>
{
    "   ",
    "",
    "\t"
}.AsReadOnly();
        var chunkSize = 4;
        var overlap = 1;

        var actualResult = textChunker.CreateChunks(input, chunkSize, overlap);

        Assert.Empty(actualResult);
    }

    [Fact]
    public void CreateChunks_MultiplePages_ReturnsExpectedChunks()
    {
        var textChunker = new TextChunker();
        var input = new List<string> { "One Two Three Four", "Five Six Seven Eight" }.AsReadOnly();
        var chunkSize = 4;
        var overlap = 1;

        var actualResult = textChunker.CreateChunks(input, chunkSize, overlap);

        actualResult.Should().HaveCount(4);
        actualResult[0].Text.Should().Be("One Two Three Four");
        actualResult[0].ChunkIndex.Should().Be(0);
        actualResult[0].PageNumber.Should().Be(1);
        actualResult[1].Text.Should().Be("Four");
        actualResult[1].ChunkIndex.Should().Be(1);
        actualResult[1].PageNumber.Should().Be(1);
        actualResult[2].Text.Should().Be("Five Six Seven Eight");
        actualResult[2].ChunkIndex.Should().Be(0);
        actualResult[2].PageNumber.Should().Be(2);
        actualResult[3].Text.Should().Be("Eight");
        actualResult[3].ChunkIndex.Should().Be(1);
        actualResult[3].PageNumber.Should().Be(2);
    }

    [Fact]
    public void CreateChunks_SmallInput_ReturnsExpectedChunks()
    {
        var textChunker = new TextChunker();
        var input = new List<string> { "One Two" }.AsReadOnly();
        var chunkSize = 4;
        var overlap = 1;

        var actualResult = textChunker.CreateChunks(input, chunkSize, overlap);

        actualResult.Should().HaveCount(1);
        actualResult[0].Text.Should().Be("One Two");
        actualResult[0].ChunkIndex.Should().Be(0);
        actualResult[0].PageNumber.Should().Be(1);
    }

    [Fact]
    public void CreateChunks_ChunkSizeSameInputSize_ReturnsExpectedChunks()
    {
        var textChunker = new TextChunker();
        var input = new List<string> { "One Two Three Four" }.AsReadOnly();
        var chunkSize = 4;
        var overlap = 1;

        var actualResult = textChunker.CreateChunks(input, chunkSize, overlap);

        actualResult.Should().HaveCount(2);
        actualResult[0].Text.Should().Be("One Two Three Four");
        actualResult[0].ChunkIndex.Should().Be(0);
        actualResult[0].PageNumber.Should().Be(1);
        actualResult[1].Text.Should().Be("Four");
        actualResult[1].ChunkIndex.Should().Be(1);
        actualResult[1].PageNumber.Should().Be(1);
    }

[Fact]
    public void CreateChunks_SinglePage_ReturnsMultipleChunks()
    {
        var textChunker = new TextChunker();
        var input = new List<string> { "One Two Three Four Five Six Seven Eight Nine Ten" }.AsReadOnly();
        var chunkSize = 4;
        var overlap = 1;

        var actualResult = textChunker.CreateChunks(input, chunkSize, overlap);

        actualResult.Should().HaveCount(4);
        actualResult[0].Text.Should().Be("One Two Three Four");
        actualResult[0].ChunkIndex.Should().Be(0);
        actualResult[0].PageNumber.Should().Be(1);
        actualResult[1].Text.Should().Be("Four Five Six Seven");
        actualResult[1].ChunkIndex.Should().Be(1);
        actualResult[1].PageNumber.Should().Be(1);
        actualResult[2].Text.Should().Be("Seven Eight Nine Ten");
        actualResult[2].ChunkIndex.Should().Be(2);
        actualResult[2].PageNumber.Should().Be(1);
        actualResult[3].Text.Should().Be("Ten");
        actualResult[3].ChunkIndex.Should().Be(3);
        actualResult[3].PageNumber.Should().Be(1);
    }
}