using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Requests;

public record MessageDto
{
    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;
    
    [JsonPropertyName("content")]
    public string Content { get; init; } =  string.Empty;
}