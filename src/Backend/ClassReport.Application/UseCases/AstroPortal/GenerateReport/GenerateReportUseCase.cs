using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Domain.Dtos.Requests;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Security.Tokens;
using MyRecipeBook.Domain.Services.AstroPortal;
using MyRecipeBook.Domain.Services.OpenAI;

namespace MyRecipeBook.Application.UseCases.AstroPortal.GenerateReport;

public class GenerateReportUseCase :  IGenerateReportUseCase
{
    private readonly ITokenProvider _token;
    private readonly IGetBookIdAndDate _bookServiceId;
    private readonly IGetBookContent _bookServiceContent;
    private readonly IGenerateReportAi _aiService;
    private readonly IGetClasses _classService;
    private readonly IGetTeacherInfo _teacherService;
    public GenerateReportUseCase(
        ITokenProvider token, 
        IGetBookIdAndDate bookServiceId, 
        IGetBookContent bookServiceContent, 
        IGenerateReportAi aiService, 
        IGetClasses classService, 
        IGetTeacherInfo teacherService)
    {
        _token = token;
        _bookServiceId = bookServiceId;
        _bookServiceContent = bookServiceContent;
        _aiService = aiService;
        _classService = classService;
        _teacherService = teacherService;
    }
    public async Task<string> Execute(RequestClassId request)
    {
        var classId = request.ClassId;
        var accessToken = _token.Value();

        var date = DateTimeInTimeZone.Brasilia();
        var today = date.DayToday();
        var dateToday = date.DateToday();
        
        var classes = await _classService.GetClassesToday(accessToken, today);
        var className = classes.Results.First(result => result.Id.ToString() == classId).Name;
        
        var teacher = await _teacherService.GetTeacherInfo(accessToken);
        var teacherName = teacher.FirstName + " " + teacher.LastName;

        var book = await _bookServiceId.GetBookIdAndDate(accessToken, classId, dateToday, dateToday);
        var bookId = book.Results[0].Lesson.Book.Id.ToString();
        var lessonDate = book.Results[0].DateTime;

        var bookResponse = await _bookServiceContent.GetBookContent(accessToken, bookId!);
        var lessonContent = bookResponse.Chapters!.Aggregate("", (current, item) => current + item.Content);
        
        var requestReport = new GenerateReportDto
        {
            LessonContent = lessonContent,
            LessonDate = lessonDate,
            LessonName = className,
            Teacher = teacherName
        };

        return await _aiService.Generate(requestReport);
    }
}