using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses.AiServices;

public record ChatCompletionResponse
{
    [JsonPropertyName("choices")]
    public List<Choice> Choices { get; set; } = [];
}