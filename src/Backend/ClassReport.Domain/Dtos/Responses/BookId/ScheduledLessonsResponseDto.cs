using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses.BookId
{
    public record ScheduledLessonsResponseDto
    {
        [JsonPropertyName("results")] 
        public List<ScheduledLessonDto>? Results { get; set; } = [];
    }
}


