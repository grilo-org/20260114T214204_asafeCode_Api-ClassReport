namespace MyRecipeBook.Domain.Dtos.Requests;

public record GenerateReportDto
{
    public string LessonContent { get; init; } = string.Empty;
    public string Teacher { get; init; } = string.Empty;
    public string LessonDate { get; init; } = string.Empty;
    public string LessonName { get; init; } =  string.Empty;
}