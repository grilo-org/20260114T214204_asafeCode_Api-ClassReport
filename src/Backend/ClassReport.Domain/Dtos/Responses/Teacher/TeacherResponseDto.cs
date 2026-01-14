using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses.Teacher;

public record TeacherResponseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }
}
