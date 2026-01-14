using System.Text.Json;
using MyRecipeBook.Domain.Dtos.Responses;
using MyRecipeBook.Domain.Dtos.Responses.BookId;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Domain.Services.AstroPortal;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services.Astro;

public class GetBookIdAndDateService : IGetBookIdAndDate
{
    private readonly ICtrlPlayClient _client;
    public GetBookIdAndDateService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public async Task<ScheduledLessonsResponseDto> GetBookIdAndDate(string accessToken, string classId, string dateRangeBefore, string dateRangeAfter)
    {
        var response = await _client.GetBookIdAndDate(accessToken, classId, dateRangeBefore, dateRangeAfter);
        if (response.IsSuccessful.IsFalse()) 
            throw new ExternalServiceException(ResourceMessagesException.NO_TOKEN);

        if (response.Content?.Results == null || response.Content.Results.Count == 0)
            throw new NotFoundException(ResourceMessagesException.BOOK_NOT_FOUND);

        if (response.Content.Results[0].Lesson!.Book is null)
            throw new NotFoundException(ResourceMessagesException.BOOK_NOT_FOUND);
        
        return response.Content!;
    }
}