using MyRecipeBook.Domain.Dtos.Requests;
using MyRecipeBook.Domain.Dtos.Responses;
using MyRecipeBook.Domain.Dtos.Responses.Login;

namespace MyRecipeBook.Domain.Services.AstroPortal;

public interface IGetAccessToken
{
    Task<TokenReponseDto> GetAccessToken(RequestLoginDto request);
}