using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses.BookContent;

public record BookResponseDto
{
    [JsonPropertyName("chapters")]
    public List<ChapterDto>? Chapters { get; set; }
}


