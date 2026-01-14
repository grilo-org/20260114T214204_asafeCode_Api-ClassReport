using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses.Classes;

public record ClassesResponseDto
{
    [JsonPropertyName("results")] 
    public List<ClassDto> Results { get; set; } = [];
}


