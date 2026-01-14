using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses.Classes;

public record ClassDto
{
    [JsonPropertyName("id")] 
    public int? Id { get; set; }
    [JsonPropertyName("name")] 
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("unit_id")]
    public int? UnitId { get; set; }
    [JsonPropertyName("teacher_id")] 
    public int? TeacherId { get; set; }
    [JsonPropertyName("status")] 
    public string Status { get; set; } = string.Empty;
}