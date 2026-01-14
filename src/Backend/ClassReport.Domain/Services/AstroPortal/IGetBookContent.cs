using System.Text.Json;
using MyRecipeBook.Domain.Dtos.Responses;
using MyRecipeBook.Domain.Dtos.Responses.BookContent;

namespace MyRecipeBook.Domain.Services.AstroPortal;

public interface IGetBookContent
{
    public Task<BookResponseDto> GetBookContent(string accessToken, string bookId);
}