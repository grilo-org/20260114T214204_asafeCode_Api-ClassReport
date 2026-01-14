using System.Text.Json.Serialization;
using MyRecipeBook.Domain.ValueModel;

namespace MyRecipeBook.Domain.Dtos.Requests;

public record ChatRequestDto
{ 
    [JsonPropertyName("model")]
    public string Model { get; set; } = ClassReportRuleConstants.ChatModel; 
    
    [JsonPropertyName("messages")]
    public List<MessageDto> Messages { get; set; } = [];
}