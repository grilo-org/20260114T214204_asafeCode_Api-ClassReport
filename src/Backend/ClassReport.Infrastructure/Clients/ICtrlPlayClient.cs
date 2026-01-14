using MyRecipeBook.Domain.Dtos.Requests;
using MyRecipeBook.Domain.Dtos.Responses.BookContent;
using MyRecipeBook.Domain.Dtos.Responses.BookId;
using MyRecipeBook.Domain.Dtos.Responses.Classes;
using MyRecipeBook.Domain.Dtos.Responses.Login;
using MyRecipeBook.Domain.Dtos.Responses.Teacher;
using Refit;

namespace MyRecipeBook.Infrastructure.Clients;

public interface ICtrlPlayClient
{
    [Post("/auth/token/")]
    public Task<IApiResponse<TokenReponseDto>> Login([Body] RequestLoginDto request);
    
    [Get("/users/me/")]
    public Task<IApiResponse<TeacherResponseDto>> GetTeacherInfo([Header("Authorization")] string accessToken);

    [Get("/classes/")]
    public Task<IApiResponse<ClassesResponseDto>> GetClasses([Header("Authorization")] string accessToken, [AliasAs("day_of_week")] string today,
        [AliasAs("status")] string statusClass = "IN_PROGRESS");

    [Get("/scheduled-lessons/?is_active=true")]
    public Task<IApiResponse<ScheduledLessonsResponseDto>> GetBookIdAndDate([Header("Authorization")] string accessToken,
        [AliasAs("klass_id")] string classId, [AliasAs("date_range_before")] string dateRangeBefore, 
        [AliasAs("date_range_after")] string dateRangeAfter);
    
    [Get("/books/{bookId}/")]
    public Task<IApiResponse<BookResponseDto>> GetBookContent([Header("Authorization")] string accessToken, string bookId);
}