using MyRecipeBook.Domain.Dtos.Responses.BookContent;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services.AstroPortal;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services.Astro;

public class GetBookContentService :  IGetBookContent
{
    private readonly ICtrlPlayClient _client;
    public GetBookContentService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public async Task<BookResponseDto> GetBookContent(string accessToken, string bookId)
    {
        var response = await _client.GetBookContent(accessToken, bookId);
        if (response.IsSuccessful.IsFalse()) 
            throw new ExternalServiceException(ResourceMessagesException.NO_TOKEN);

        return response.Content!;
    }
}