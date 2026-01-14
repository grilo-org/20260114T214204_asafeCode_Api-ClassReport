using System.Text.Json.Serialization;
using MyRecipeBook.Domain.Dtos.Requests;

namespace MyRecipeBook.Domain.Dtos.Responses.AiServices;

public record Choice
{
    [JsonPropertyName("message")] 
    public MessageDto? Message { get; set; }
}