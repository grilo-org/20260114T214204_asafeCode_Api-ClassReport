using System.Text.Json;
using MyRecipeBook.Domain.Dtos.Responses;
using MyRecipeBook.Domain.Dtos.Responses.BookId;

namespace MyRecipeBook.Domain.Services.AstroPortal;

public interface IGetBookIdAndDate
{
    public Task<ScheduledLessonsResponseDto> GetBookIdAndDate (string accessToken, string classId,  string dateRangeBefore, 
         string dateRangeAfter);
}