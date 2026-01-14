using System.Text.Json.Serialization;
using MyRecipeBook.Domain.Dtos.Responses.BookId;

namespace MyRecipeBook.Domain.Dtos.Responses.BookContent;

public record LessonContentResponseDto
{
    [JsonPropertyName("results")] 
    public List<BookResponseDto>? Results { get; set; } = [];
}